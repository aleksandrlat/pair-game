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
		},
		invite: function(invite){
			return '' +
			'<div id="inv-'+ invite.id +'" class="invite">' +
				'<div class="photo" title="'+ invite.name +'" style="background-image: url('+ invite.photo +')"></div>' +
				'<div class="btn">Начать игру</div>' +
			'</div>';
		}
	},

	parent = function(el, className){
		while (!el.classList.contains(className)) {
			el = el.parentNode;
			if (!el) {
				break;
			}
		}
		return el;
	},

	invite = function(e){
		this.ws.send({method: 'invite', id: parent(e.target, 'player').id.substr(3)});
	},

	startGame = function(e){
		this.ws.send({method: 'startGame', id: parent(e.target, 'invite').id.substr(4)});
	},

	stopGame = function(e){
		this.area.style.display = 'none';
		if (this.playingId) {
			this.ws.send({method: 'stopGame'});
		}
	},

	answer = function(e){
		if (e.target.classList.contains('answer')) {
			this.ws.send({method: 'answer', answer: e.target.dataset.id});
			this.wait.style.display = 'block';
			this.answers.style.display = 'none';
		}
	},

	onmessage = function(data){
		console.log(data);
		this['on'+ data.method](data);
	};

	function Game(ws, player, players){
		this.ws = ws;
		this.player = player;

		this.players = byId('players');
		this.invites = byId('invites');

		this.renderPlayers(players);
		this.players.onclick = invite.bind(this);
		this.invites.onclick = startGame.bind(this);
		ws.onmessage = onmessage.bind(this);
	}

	proto.renderPlayers = function(players){
		var str = '';
		for (var i in players) {
			str += templates.player(players[i]);
		}
		this.players.innerHTML = str + this.players.innerHTML;
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
		this.invites.getElementsByClassName('empty')[0].style.display = 'none';
		this.invites.innerHTML = templates.invite(data.player) + this.invites.innerHTML;
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
			return;		}
		var invite = byId('inv-'+ data.player.id);
		invite && invite.remove();
		if (this.invites.getElementsByClassName('invite').length <= 0) {
			this.invites.getElementsByClassName('empty')[0].style.display = 'block';
		}

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