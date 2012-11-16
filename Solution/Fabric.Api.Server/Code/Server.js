/// <reference path="node-vsdoc.js" />

var http = require('http');
var url = require("url");

http.createServer(onRequest).listen(9000, "127.0.0.1");
console.log('Server running at http://127.0.0.1:9000/');


////////////////////////////////////////////////////////////////////////////////////////////////////////
/*----------------------------------------------------------------------------------------------------*/
function onRequest(pRequest, pResponse) {
	var parsed = url.parse(pRequest.url);
	console.log("Request: " + pRequest.method + " " + parsed.pathname + "?" + parsed.query);

	if (parsed.pathname.indexOf("testform") != -1) {
		writeTestForm(pResponse);
		return;
	}

	pResponse.writeHead(200, { "Content-Type": "text/plain" });
	pResponse.write("method: " + pRequest.method + "\n");
	pResponse.write("pathname: " + parsed.pathname + "\n");
	pResponse.write("query: " + parsed.query + "\n");

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
		pResponse.write("post: " + postData + "\n");
		pResponse.end();
	});
}

/*----------------------------------------------------------------------------------------------------*/
function writeTestForm(pResponse) {
	pResponse.writeHead(200, { "Content-Type": "text/html" });
	pResponse.write('<html xmlns="http://www.w3.org/1999/xhtml"><body>');
	pResponse.write('<form action="post/forms/here" method="post">');
	pResponse.write('<textarea name="text" rows="10" cols="80"></textarea>');
	pResponse.write('<input type="submit" value="Submit" /></form></body></html>');
	pResponse.end();
}