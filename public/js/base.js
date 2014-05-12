module.define([], 'base', function(){
var

WS = (function(){
	var proto = WS.prototype,

	onmessage = function(e){
		this.onmessage(JSON.parse(e.data));
	},

	onopen = function(e){
		this.onopen(e);
	};

	function WS(ws){
		this.ws = ws;
		this.ws.onmessage = onmessage.bind(this);
		this.ws.onopen = onopen.bind(this);
	}

	proto.send = function(data){
		this.ws.send(JSON.stringify(data));
	};

	proto.onmessage = function(data){
		console.log(data);
	};

	proto.onopen = function(e){
		console.log(e);
	};

	return WS;
})();

return {
	WS: WS
};
});
