/// <reference path="node-vsdoc.js" />

var NodeHttp = require('http');
var NodeUrl = require("url");
var NodeChild = require('child_process');
var NodeQueryStr = require('querystring');

/* ---- DEBUG ---- */
var vPort = 9000;
var vWorkerPath = "Z:\\Work\\AestheticInteractive\\FabricProject\\"+
	"Fabric2\\Solution\\Fabric.Api.Worker\\bin\\Debug\\";

/* --- RELEASE --- * /
var vPort = 80;
var vWorkerPath = "";

/* ---- NOTES ---- * /

- Support OAuth
-- initial sign-in
-- all authorization flows


*/

NodeHttp.createServer(onRequest).listen(vPort, "127.0.0.1");
console.log("ApiServer running at http://127.0.0.1:"+vPort+"/");


////////////////////////////////////////////////////////////////////////////////////////////////////////
/*----------------------------------------------------------------------------------------------------*/
function onRequest(pRequest, pResponse) {
	var parsed = NodeUrl.parse(pRequest.url);

	if ( ignoreRequest(parsed) ) {
		pResponse.end();
		return;
	}

	console.log("Request: "+pRequest.method+" "+parsed.pathname+(parsed.query ? "?"+parsed.query : ""));

	getPostData(pRequest, pResponse, function(pPostData) {
		beginWorker2(pRequest, pResponse, parsed, pPostData);
	});
}

/*----------------------------------------------------------------------------------------------------*/
function ignoreRequest(pParsedUrl) {
	var path = pParsedUrl.pathname;
	if ( path.substring(path.length-4) == ".ico" ) { return true; }
	return false;
}

/*----------------------------------------------------------------------------------------------------*/
function getPostData(pRequest, pResponse, pOnComplete) {
	var data = "";
	var len = 0;

	pRequest.addListener("data", function(pChunk) {
		data += pChunk;
		len += pChunk.length;

		if (len > 100000) {
			pResponse.write("POST data too large.\n");
			pResponse.end();
		}
	});

	pRequest.addListener("end", function() {
		pOnComplete(data);
	});
}


////////////////////////////////////////////////////////////////////////////////////////////////////////
/*----------------------------------------------------------------------------------------------------*/
function beginWorker(pRequest, pResponse, pParsedUrl, pPostData) {
	var worker = NodeChild.spawn(vWorkerPath+"Fabric.Api.Worker.exe", [
		pRequest.method,
		pParsedUrl.pathname,
		pParsedUrl.query,
		pPostData
	]);

	var workerData = "";

	worker.stdout.on("data", function(pData) {
		workerData += pData;
	});

	worker.on("exit", function(pCode) {
		var dataStr = "&data=#\n";
		var dataI = workerData.indexOf(dataStr)+dataStr.length;

		if ( dataI == -1 ) {
			onWorkerError(pResponse, workerData);
			return;
		}
		
		var metaStr = workerData.substring(0, dataI);
		var meta = NodeQueryStr.parse(metaStr);

		if ( meta.error == "1" ) {
			onWorkerError(pResponse, workerData);
			return;
		}
		else {
			var json = workerData.substring(dataI);
			pResponse.write(json);
		}
		
		pResponse.writeHead(meta.status, { "Content-Type": "text/plain" });
		pResponse.end();
	});
}

/*----------------------------------------------------------------------------------------------------*/
function onWorkerError(pResponse, pWorkerData) {
	console.log("WORKER ERROR: "+pWorkerData);
	pResponse.writeHead(500, { "Content-Type": "text/plain" });
	pResponse.write("Server 500 Error");
	pResponse.end();
}


////////////////////////////////////////////////////////////////////////////////////////////////////////
/*----------------------------------------------------------------------------------------------------*/
function beginWorker2(pRequest, pResponse, pParsedUrl, pPostData) {
	var opt = {
		method: "POST",
		host: "localhost",
		port: 9001,
		path: "/"
	};

	var dbReq = NodeHttp.request(opt, function(pDbResp) { 
		onDbResponse(pDbResp, pResponse);
	});

	dbReq.write('{"script":"g.v(99);"}');
	dbReq.end();
}

/*----------------------------------------------------------------------------------------------------*/
function onDbResponse(pDbResp, pResponse) {
	var data = "";

	pDbResp.on("data", function(pChunk) {
		data += pChunk;
	});
	
	pDbResp.on("end", function() {
		pResponse.write(data);
		pResponse.end();
	});

	pDbResp.on("error", function(pError) {
		console.log("ERROR: "+pError.message);
	});
}