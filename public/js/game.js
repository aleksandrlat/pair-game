module.define([], 'game', function(){
var

Game = (function(window, byId){
	var proto = Game.prototype,

	onmessage = function(data){
		this['on'+ data.method](data);
	};

	function Game(ws, player, players){
		this.ws = ws;
		this.player = player;

		this.elPlayers = byId('players');
		this.renderPlayers(players);

		ws.onmessage = onmessage.bind(this);
	}

	proto.renderPlayers = function(players){
		var str = '';
		for (var player in players) {
			player = players[player];
			if (player.id == this.player.id) {
				str +=
				'<span id="pl-'+ player.id +'" class="gameCurPlayer">' +
					'<div><img src="'+ player.photo +'"></div>' +
					'<div>'+ player.name +' ('+ player.gender +')</div>' +
				'</span>';
			} else {
				str +=
				'<a href="javascript:" id="pl-'+ player.id +'" class="gamePlayer">' +
					'<div><img src="'+ player.photo +'"></div>' +
					'<div>'+ player.name +' ('+ player.gender +')</div>' +
				'</a>';
			}
		}
		this.elPlayers.innerHTML = str + this.elPlayers.innerHTML;
	};

	return Game;
})(window, window.document.getElementById.bind(window.document));

return {
	Game: Game
};
});