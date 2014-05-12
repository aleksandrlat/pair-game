var Module = (function(window){
var proto = Module.prototype,

Loader = (function(window){
	var proto = Loader.prototype,

	scripts = {};

	function Loader(){}

	proto.load = function(path){
		if (scripts[path]) {
			return;
		}

		var script = window.document.createElement('SCRIPT');
		script.async = true;
		script.type = 'text/javascript';
		script.charset = 'UTF-8';
		script.src = path;
		window.document.getElementsByTagName('HEAD')[0].appendChild(script);

		scripts[path] = path;
	};

	return Loader;
})(window);

function Module(basePath, nameModuleMap){
	this.basePath = basePath;
	this.map = nameModuleMap || {};

	this.modules = {};
	this.loader = new Loader();
	this.definedEvents = {};
}

proto.define = function(dependecies, name, create){
	var i;

	if (dependecies.length <= 0) {
		this.modules[name] = create();
		if (this.definedEvents[name]) {
			for (i = 0; i < this.definedEvents[name].length; i++) {
				this.definedEvents[name][i]();
			}
			delete this.definedEvents[name];
		}
		return;
	}

	var onDefined = function(){
		var args = [];
		for (var i = 0; i < dependecies.length; i++) {
			var dependency = dependecies[i];
			if (this.modules[dependency]) {
				args.push(this.modules[dependency]);
			} else {
				return;
			}
		}
		this.modules[name] = create.apply(window, args);
	}.bind(this);

	var args = [];
	for (i = 0; i < dependecies.length; i++) {
		var dependency = dependecies[i];
		if (this.modules[dependency]) {
			args.push(this.modules[dependency]);
			continue;
		}

		if (!this.definedEvents[dependency]) {
			this.definedEvents[dependency] = [];
		}
		this.definedEvents[dependency].push(onDefined);

		this.loader.load(this.map[dependency] ? this.map[dependency] : this.basePath + dependency +'.js');
	}

	if (args.length == dependecies.length) {
		this.modules[name] = create.apply(window, args);
	}
};

return Module;
})(window);