module.define([], 'game', function(){
var

Game = (function(window){
	var proto = Game.prototype;

	function Game(ws, player, players){
		this.ws = ws;
		this.player = player;
	}

	return Game;
})(window);

return {
	Game: Game
};
});