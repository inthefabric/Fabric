/// <reference path="node-vsdoc.js" />

var NodeHttp = require('http');
var NodeUrl = require("url");
var NodeChild = require('child_process');
var NodeQueryStr = require('querystring');

/* ---- DEBUG ---- */
var vPort = 9000;
var vWorkerPath = "Z:\\Work\\AestheticInteractive\\FabricProject\\"+
	"Fabric2\\Solution\\Fabric.Api.Worker\\bin\\Debug\\";
/**/

/* --- RELEASE --- * /
var vPort = 80;
var vWorkerPath = "";
/**/

NodeHttp.createServer(onRequest).listen(vPort, "127.0.0.1");
console.log("ApiServer running at http://127.0.0.1:"+vPort+"/");


////////////////////////////////////////////////////////////////////////////////////////////////////////
/*----------------------------------------------------------------------------------------------------*/
function onRequest(pRequest, pResponse) {
	var parsed = NodeUrl.parse(pRequest.url);
	var pathAndQuery = pRequest.method+" "+parsed.pathname+(parsed.query ? "?"+parsed.query : "");

	console.log("Request: "+pathAndQuery);

	/*if ( parsed.pathname.indexOf("testform") != -1 ) {
		writeTestForm(pResponse);
		return;
	}*/

	var postData = "";
	var postLen = 0;

	pRequest.addListener("data", function(pChunk) {
		postData += pChunk;
		postLen += pChunk.length;

		if (postLen > 100000) {
			pResponse.write("POST data too large.\n");
			pResponse.end();
		}
	});

	pRequest.addListener("end", function() {
		beginWorker(pRequest, pResponse, parsed, postData);
	});
}

/*----------------------------------------------------------------------------------------------------* /
function writeTestForm(pResponse) {
	pResponse.writeHead(200, { "Content-Type": "text/html" });
	pResponse.write('<html><body><form action="post/forms/here" method="post">');
	pResponse.write('<textarea name="text" rows="10" cols="80"></textarea>');
	pResponse.write('<input type="submit" value="Submit" /></form></body></html>');
	pResponse.end();
}

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
		var curlyI = workerData.indexOf("\n{");

		if ( curlyI == -1 ) {
			console.log("WORKER RESPONSE ERROR: "+workerData);
			pResponse.writeHead(500, { "Content-Type": "text/plain" });
			pResponse.end();
			return ;
		}
		
		var metaStr = workerData.substring(0, curlyI);
		var meta = NodeQueryStr.parse(metaStr);
		var json = workerData.substring(curlyI+1);

		/*pResponse.write("worker exit code: "+pCode+"\n");
		pResponse.write("metaStr: "+metaStr+"\n");
		pResponse.write("meta.status: "+meta.status+"\n");
		pResponse.write("meta.error: "+meta.error+"\n");
		pResponse.write("meta.other: "+meta.other+"\n");
		pResponse.write("meta.nothing: "+meta.nothing+"\n\n");*/

		pResponse.writeHead(meta.status, { "Content-Type": "text/plain" });
		pResponse.write(json);
		pResponse.end();
	});
}