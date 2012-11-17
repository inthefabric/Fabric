/// <reference path="node-vsdoc.js" />

var NodeHttp = require('http');

var vPort = 9001;

var vOptions = {
	method: "POST",
	host: "localhost",
	port: 7474,
	path: "/db/data/ext/GremlinPlugin/graphdb/execute_script"
};

NodeHttp.createServer(onRequest).listen(vPort, "127.0.0.1");
console.log("DbServer running at http://127.0.0.1:"+vPort+"/");


////////////////////////////////////////////////////////////////////////////////////////////////////////
/*----------------------------------------------------------------------------------------------------*/
function onRequest(pRequest, pResponse) {
	var queryData = "";
	var queryLen = 0;

	pRequest.addListener("data", function(pChunk) {
		queryData += pChunk;
		queryLen += pChunk.length;

		if ( queryLen > 100000 ) {
			pResponse.write("Query data too large./n");
			pResponse.end();
		}
	});

	pRequest.addListener("end", function() {
		//queryData = '{"script": "g.V", "params": {}}';
		onQueryData(pResponse, queryData);
	});
}

/*----------------------------------------------------------------------------------------------------*/
function onQueryData(pResponse, pQueryData) {
	if ( !pQueryData ) {
		console.log("No query data!");
		pResponse.end();
		return;
	}

	var gremReq = NodeHttp.request(vOptions, function(pGremResp) { 
		onGremResponse(pGremResp, pResponse);
	});

	gremReq.write(pQueryData);
	gremReq.end();

	console.log("Gremlin: "+pQueryData);
}

/*----------------------------------------------------------------------------------------------------*/
function onGremResponse(pGremResp, pResponse) {
	var gremData = "";

	pGremResp.on("data", function(pChunk) {
		gremData += pChunk;
	});
	
	pGremResp.on("end", function() {
		pResponse.write(fixGremData(gremData));
		pResponse.end();
	});

	pGremResp.on("error", function(pError) {
		console.log("ERROR: "+pError.message);
	});
}


////////////////////////////////////////////////////////////////////////////////////////////////////////
/*----------------------------------------------------------------------------------------------------*/
function fixGremData(pGremData) {
	var obj = JSON.parse(pGremData);

	if ( Array.isArray(obj) ) {
		for ( var key in obj ) {
			fixGremDataItem(obj[key]);
		}
	}
	else {
		fixGremDataItem(obj);
	}

	return JSON.stringify(obj)
		.replace(/http:\/\/localhost:7474\/db\/data\//g, "")
		.replace(/(?:":")node\//g, "\":\"n/")
		.replace(/(?:":")relationship\//g, "\":\"r/");
}

/*----------------------------------------------------------------------------------------------------*/
function fixGremDataItem(pItem) {
	delete pItem.outgoing_relationships;
	delete pItem.traverse;
	delete pItem.all_typed_relationships;
	delete pItem.property;
	delete pItem.properties;
	delete pItem.outgoing_typed_relationships;
	delete pItem.incoming_relationships;
	delete pItem.extensions;
	delete pItem.create_relationship;
	delete pItem.paged_traverse;
	delete pItem.all_relationships;
	delete pItem.incoming_typed_relationships;
}