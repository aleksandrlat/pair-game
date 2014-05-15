module.define([], 'game', function(){
var

Game = (function(window, byId){
	var proto = Game.prototype,

	templates = {
		player: function(player){
			return ''+
			'<div id="pl-'+ player.id +'" class="player">' +
				'<div class="photo" title="'+ player.name +'" style="background-image: url('+ player.photo +')">' +
					'<div class="gender '+ player.gender +'"></div>' +
				'</div>' +
				'<div class="btn">Пригласить</div>' +
			'</div>';
		}
	},

	onmessage = function(data){
		console.log(data);
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
		for (var i in players) {
			for (var j = 0; j < 10; ++j) {
				str += templates.player(players[i]);
			}
		}
		this.elPlayers.innerHTML = str + this.elPlayers.innerHTML;
	};

	proto.oninvite = function(data){
		if (data.error) {
			alert(data.error);
			return;
		}
		var existed = byId('inv-'+ data.player.id);
		if (existed) {
			existed.remove();
		}
		this.invites.innerHTML += '<a href="javascript:" id="inv-'+ data.player.id +'" class="gameInvite">'+ data.player.name +'</a>';
	};

	proto.onadd = function(data){
		if (this.player.id != data.player.id) {
			var player = {};
			player[data.player.id] = data.player;
			this.renderPlayers(player);
		}
	};

	proto.onremove = function(data){
		var
			player = byId('pl-'+ data.player.id),
			invite = byId('inv-'+ data.player.id);

		player && player.remove();
		invite && invite.remove();

		if (data.player.id == this.playingId) {
			this.onstopGame();
		}
	};

	proto.onstartGame = function(data){
		if (data.error) {
			alert(data.error);
			return;
		}
		var invite = byId('inv-'+ data.player.id);
		invite && invite.remove();

		this.questionBody.textContent = data.question;
		this.result.textContent = 'Game messages home';
		this.questionNum.textContent = 1;
		this.area.style.display = 'inline-block';
		this.answers.onclick = answer.bind(this);

		this.playingId = data.player.id;
	};

	proto.onstopGame = function(){
		this.playingId = '';
		this.answers.onclick = null;
		this.result.textContent = 'User stoped game. Sorry.';
	};

	proto.onanswer = function(data){
		if (data.error) {
			alert(data.error);
			return;
		}
		this.result.textContent = 'User answered: '+ (data.answer == 1 ? 'Yes' : 'No');
		if (data.result) {
			this.answers.onclick = null;
			this.result.innerHTML += '<br>Game finished. You result: '+ data.result +'%';
			this.playingId = '';
		} else {
			var questionNum = parseInt(this.questionNum.textContent);
			this.questionNum.textContent = ++questionNum;
			this.questionBody.textContent = data.question;

			this.wait.style.display = 'none';
			this.answers.style.display = 'block';
		}
	};

	return Game;
})(window, window.document.getElementById.bind(window.document));

return {
	Game: Game
};
});