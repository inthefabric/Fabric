## Fabric

[InTheFabric.com](http://www.inTheFabric.com)

Fabric provides a new way of describing our world, and all the "things" in it. It emphasizes information-filled relationships between items, which adds context and meaning to all connected items. Fabric maintains meaningful data, facts, and opinions within a powerful descriptive framework that can easily be accessed, traversed, and interpreted by computers.

This GitHub project is for the Fabric API. Once an app or website sets up an account with Fabric, they can use the API to create new items, connect them into Fabric's existing heirarchies of meaning, and describe them as desired. These additions and changes are available to all apps and users.

#### Implementation Details

Fabric is written in C# for .NET/Mono. A pre-built .NET/Mono client (built entirely from Fabric's API spec) is available in the [FabricSharpClient](https://github.com/inthefabric/FabricSharpClient) project.

Fabric uses the [Titan](http://thinkaurelius.github.io/titan/) graph database, with [Cassandra](http://cassandra.apache.org/) and [ElasticSearch](http://www.elasticsearch.org/) as storage/indexing engines. It also uses a wide variety of other open source projects -- a growing list is [available here](http://www.inthefabric.com/Explore).

Fabric has separated some of its key functionality into separate projects here at GitHub: [Weaver](https://github.com/inthefabric/Weaver) and [RexConnect](https://github.com/inthefabric/RexConnect).

#### More Information

Please visit the [Fabric website](http://www.inTheFabric.com), or jump directly to Fabric's [API documentation](http://www.inTheFabric.com/docs/reference).


[![githalytics.com alpha](https://cruel-carlota.pagodabox.com/017600c71999597bffa109de0a090010 "githalytics.com")](http://githalytics.com/inthefabric/Fabric)
