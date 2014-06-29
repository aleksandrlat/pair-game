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

	initGame = function(gameEl, player){
		if (gameEl.question) {
			return;
		}

		gameEl.left = gameEl.getElementsByClassName('left')[0];
		gameEl.right = gameEl.getElementsByClassName('right')[0];
		gameEl.question = gameEl.getElementsByClassName('question')[0];

		gameEl.left.name = gameEl.left.getElementsByClassName('name')[0];
		gameEl.left.photo = gameEl.left.getElementsByClassName('photo')[0];
		gameEl.left.result = gameEl.left.getElementsByClassName('result')[0];

		gameEl.right.name = gameEl.right.getElementsByClassName('name')[0];
		gameEl.right.photo = gameEl.right.getElementsByClassName('photo')[0];
		gameEl.right.result = gameEl.right.getElementsByClassName('result')[0];

		gameEl.question.num = 0;
		gameEl.question.type = gameEl.question.getElementsByClassName('type')[0];
		gameEl.question.text = gameEl.question.getElementsByClassName('text')[0];
		gameEl.question.answers = gameEl.question.getElementsByClassName('answers')[0];
		gameEl.question.answers.btns = gameEl.question.answers.getElementsByClassName('btns')[0];
		gameEl.question.answers.wait = gameEl.question.answers.getElementsByClassName('wait')[0];
		gameEl.question.answers.result = gameEl.question.answers.getElementsByClassName('result')[0];

		gameEl.left.name.textContent = player.name;
		gameEl.left.photo.style.backgroundImage = 'url('+ player.photo +')';
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
		if (e.target.classList.contains('btn')) {
			this.ws.send({method: 'answer', answer: e.target.dataset.id});
			this.gameArea.question.answers.answer = e.target.dataset.id;
			this.gameArea.question.answers.btns.style.display = 'none';
			this.gameArea.question.answers.wait.style.display = 'block';

			this.gameArea.left.result.textContent = (e.target.dataset.id == 1 ? 'Да' : 'Нет');
			this.gameArea.left.result.style.backgroundColor = (e.target.dataset.id == 1 ? 'green' : 'red');

			this.gameArea.left.name.style.display = 'none';
			this.gameArea.left.result.style.display = 'block';
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
		this.gameArea = byId('gameArea');
		this.mainTitle = byId('container').getElementsByTagName('h1')[0];

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
			return;
		}
		var invite = byId('inv-'+ data.player.id);
		invite && invite.remove();
		if (this.invites.getElementsByClassName('invite').length <= 0) {
			this.invites.getElementsByClassName('empty')[0].style.display = 'block';
		}

		initGame(this.gameArea, this.player);

		this.mainTitle.textContent = 'Вопрос номер 1';
		this.gameArea.right.name.textContent = data.player.name;
		this.gameArea.right.photo.style.backgroundImage = 'url('+ data.player.photo +')';
		this.gameArea.question.text.textContent = data.question;
		this.gameArea.question.num = 1;
		this.gameArea.style.display = 'block';

		this.players.style.display = 'none';

		this.gameArea.question.answers.onclick = answer.bind(this);

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

		var resultColor = '', resultText = '';
		if (this.gameArea.question.answers.answer == data.answer) {
			resultColor = 'green';
			resultText = 'Совпало';
		} else {
			resultColor = 'red';
			resultText = 'Не совпало';
		}

		this.gameArea.question.answers.result.textContent = resultText;
		this.gameArea.question.answers.result.style.backgroundColor = resultColor;

		this.gameArea.question.answers.wait.style.display = 'none';
		this.gameArea.question.answers.result.style.display = 'block';

		this.gameArea.right.result.textContent = (data.answer == 1 ? 'Да' : 'Нет');
		this.gameArea.right.result.style.backgroundColor = (data.answer == 1 ? 'green' : 'red');

		this.gameArea.right.name.style.display = 'none';
		this.gameArea.right.result.style.display = 'block';

		if (data.result) {
			this.answers.onclick = null;
			this.result.innerHTML += '<br>Game finished. You result: '+ data.result +'%';
			this.playingId = '';
		} else {
			setTimeout(function(){
				this.mainTitle.textContent = 'Вопрос номер '+ (++this.gameArea.question.num);
				this.gameArea.question.text.textContent = data.question;

				this.gameArea.question.answers.result.style.display = 'none';
				this.gameArea.question.answers.btns.style.display = 'block';

				this.gameArea.left.result.style.display = 'none';
				this.gameArea.left.name.style.display = 'block';

				this.gameArea.right.result.style.display = 'none';
				this.gameArea.right.name.style.display = 'block';
			}.bind(this), 2000);
		}
	};

	return Game;
})(window, window.document.getElementById.bind(window.document));

return {
	Game: Game
};
});