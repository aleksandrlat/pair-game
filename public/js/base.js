module.define([], 'base', function(){
var

WS = (function(){
	var proto = WS.prototype,

	onmessage = function(e){
		this.onmessage(JSON.parse(e.data));
	};

	function WS(ws){
		this.ws = ws;
		this.ws.onmessage = onmessage.bind(this);
	}

	proto.send = function(data){
		this.ws.send(JSON.stringify(data));
	};

	proto.onmessage = function(data){
		console.log(data);
	};

	return WS;
})();

return {
	WS: WS
};
});
