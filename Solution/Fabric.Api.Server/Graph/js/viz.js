var vColor = d3.scale.category20b();
var vDrawAll = false;


////////////////////////////////////////////////////////////////////////////////////////////////////////
/*----------------------------------------------------------------------------------------------------*/
function render(pDivId, pWidth, pHeight, pUrl) {
	d3.json(pUrl, function(pData) {
		visualize(pDivId, pWidth, pHeight, pData);
	});
}

/*----------------------------------------------------------------------------------------------------*/
function viz(pQuery) {
	var graph = $("#graph");
	graph.empty();

	//visualize("graph", graph.width(), graph.height(), data); //for static data
	render("graph", graph.width(), graph.height(), "../json?q="+pQuery);

	graph.show();
}


////////////////////////////////////////////////////////////////////////////////////////////////////////
/*----------------------------------------------------------------------------------------------------*/
function visualize(pGraphId, pWidth, pHeight, pData) {
	var vis = d3.select("#" + pGraphId).append("svg")
    .attr("width", pWidth)
    .attr("height", pHeight);

	for (var i = 0; i < pData.nodes.length; ++i) {
		var n = pData.nodes[i];
		n.x *= pWidth;
		n.y *= pHeight;
	}

	var force = self.force = d3.layout.force()
        .nodes(pData.nodes)
        .links(pData.links)
        .gravity(.2)
        //.distance(1)
        .charge(-Math.min(pWidth,pHeight)*0.1)
		.friction(0.8)
        .size([pWidth, pHeight])
        .start();

	if ( vDrawAll ) {
		// end-of-line arrow
		vis.append("svg:defs").selectAll("marker")
			.data(["end-marker"]) // link types if needed
			.enter().append("svg:marker")
			.attr("id", String)
			.attr("viewBox", "0 -5 10 10")
			.attr("refX", 25)
			.attr("refY", -1.5)
			.attr("markerWidth", 6)
			.attr("markerHeight", 6)
			.attr("class", "marker")
			.attr("orient", "auto")
			.append("svg:path")
			.attr("d", "M0,-5L10,0L0,5");
	}

	var link = vis.selectAll("line.link")
        .data(pData.links)
        .enter().append("svg:line")
        .attr("class", "link")
	  	.attr("marker-end", function (d) { return "url(#" + "end-marker" + ")"; }) // was d.type
	//.style("stroke", function (d) { var sel = d["selected"]; return sel ? "red" : null; })
	//.style("stroke-width", function (d) { return d["selected"] ? 2 : null; })
        .attr("x1", function (d) { return d.source.x; })
        .attr("y1", function (d) { return d.source.y; })
        .attr("x2", function (d) { return d.target.x; })
        .attr("y2", function (d) { return d.target.y; });

	var node = vis.selectAll("g.node")
        .data(pData.nodes)
        .enter().append("circle")
        .attr("class", function (d) { return "node" + d.Class; })
	    .attr("r", 3)
	//.style("fill", function (d) { return vColor(propertyHash(d.name) % 20); })
	//.style("stroke-width", function (d) { return d["selected"] ? 2 : 0; })
	//.style("stroke", function (d) { var sel = d["selected"]; return sel ? "red" /* was d3.rgb(color2(hash(sel) % 20)).brighter() */ : null; })
        .call(force.drag);

	node.append("title")
		.text(function (d) { return toString(d); });

	if (vDrawAll) {
		var text = vis.append("svg:g").selectAll("g")
			.data(force.nodes())
			.enter().append("svg:g");

		// A copy of the text with a thick white stroke for legibility.
		/*text.append("svg:text")
			.attr("x", 8)
			.attr("y", "-.31em")
			//.attr("class", "text shadow")
			.text(function (d) { return title(d); });*/

		text.append("svg:text")
			.attr("x", 8)
			.attr("y", "-.31em")
			.attr("class", "text")
			.text(function (d) { return title(d); });

		var path_text = vis.append("svg:g").selectAll("g")
			.data(force.links())
			.enter().append("svg:g");

		path_text.append("svg:text")
			.attr("class", "path-text shadow")
			.text(function (d) { return d.type; });

		path_text.append("svg:text")
			.attr("class", "path-text")
			.text(function (d) { return d.type; });
	}

	force.on("tick", function () {
		for (var i = 0; i < pData.nodes.length; ++i) {
			var n = pData.nodes[i];
			if ( n.x < 4 ) { n.x = 4; }
			if ( n.y < 4 ) { n.y = 4; }
			if ( n.x > pWidth-4 ) { n.x = pWidth-4; }
			if (n.y > pHeight-4 ) { n.y = pHeight-4; }
		}

		link.attr("x1", function (d) { return d.source.x; })
          .attr("y1", function (d) { return d.source.y; })
          .attr("x2", function (d) { return d.target.x; })
          .attr("y2", function (d) { return d.target.y; });

		node.attr("transform", function (d) { return "translate(" + d.x + "," + d.y + ")"; });

		if (vDrawAll) {
			text.attr("transform", function (d) {
				return "translate(" + d.x + "," + d.y + ")";
			});

			path_text.attr("transform", function (d) {
				var dx = (d.target.x - d.source.x),
				dy = (d.target.y - d.source.y);
				var dr = Math.sqrt(dx * dx + dy * dy);
				var sinus = dy / dr;
				var cosinus = dx / dr;
				var l = d.type.length * 6;
				var offset = (1 - (l / dr)) / 2;
				var x = (d.source.x + dx * offset);
				var y = (d.source.y + dy * offset);
				return "translate(" + x + "," + y + ") matrix(" +
					cosinus + ", " + sinus + ", " + -sinus + ", " + cosinus + ", 0 , 0)";
			});
		}
	});
}


////////////////////////////////////////////////////////////////////////////////////////////////////////
/*----------------------------------------------------------------------------------------------------*/
function hash(s) {
	if (!s) return 0;
	for (var ret = 0, i = 0, len = s.length; i < len; i++) {
		ret = (31 * ret + s.charCodeAt(i)) << 0;
	}
	return ret;
}

/*----------------------------------------------------------------------------------------------------*/
function propertyHash(ob) {
	var ret = 0;
	for (var prop in ob) {
		if (ob.hasOwnProperty(prop)) {
			ret += hash(prop);
		}
	}
	return ret;
}

/*----------------------------------------------------------------------------------------------------*/
function toString(ob) {
	var ret = "";
	for (var prop in ob) {
		
		switch (prop) {
			case "weight":
			//case "px":
			//case "py":
			//case "x":
			//case "y":
				continue;
		}

		if (ob.hasOwnProperty(prop)) {
			ret += prop + ": " + ob[prop] + "\n";
		}
	}
	return ret;//  + "id: " + ob.id;
}

/*----------------------------------------------------------------------------------------------------*/
function title(ob) {
	if (ob.name) return ob.name;
	if (ob.title) return ob.title;
	for (var prop in ob) {
		if (ob.hasOwnProperty(prop)) {
			return ob[prop];
		}
	}
	return ob.id;
}