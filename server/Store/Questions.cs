using System;
using System.Collections.Generic;

namespace Game.Store
{
	public class Questions
	{
		private Random rnd = new Random();

		public Dictionary<String, String> getQuestion (Model.Player player1, Model.Player player2)
		{
			int randQuestionNum = this.rnd.Next(this.data.GetLength(1));
			return this.data[randQuestionNum].format (new Model.Player[] {player1, player2});
		}

		private interface IQuestion
		{
			Dictionary<String, String> format (Model.Player[] players);
		}

		private class TwoVariants: IQuestion
		{
			private String[][] questions = new String[2][];

			public TwoVariants (String[][] questions)
			{
				this.questions = questions;
			}

			public Dictionary<String, String> format (Model.Player[] players)
			{
				Dictionary<String, String> result = new Dictionary<String, String> (2);
				Int32 i = 0, j = 0;
				foreach (Model.Player player in players) {
					if (this.questions[i].Length == 1) {
						j = 0;
					} else {
						j = (Int32)player.gender;
					}
					result [player.id] = this.questions[i][j].Replace("{name}", player.name);
					i++;
				}
				return result;
			}
		}

		private class OneVariant: IQuestion
		{
			private String[] questions;

			public OneVariant (String[] questions)
			{
				this.questions = questions;
			}

			public Dictionary<String, String> format (Model.Player[] players)
			{
				Dictionary<String, String> result = new Dictionary<String, String> (2);
				Int32 j = 0;
				foreach (Model.Player player in players) {
					if (this.questions.Length == 1) {
						j = 0;
					} else {
						j = (Int32)player.gender;
					}
					result [player.id] = this.questions[j].Replace("{name}", player.name);
				}
				return result;
			}
		}

		private IQuestion[] data = new IQuestion[] {
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты вкусно готовишь?",
				},
				new String[] {
					"Ты считаешь, что {name} вкусно готовит?",
				},
			}),
			new OneVariant(new String[] {
				"Ты любишь цветы?",
				"Как думаешь, {string} любит цветы?",
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты водишь машину?",
				},
				new String[] {
					"{name} сама водит машину?",
					"{name} сам водит машину?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь смотреть мелодрамы?",
				},
				new String[] {
					"Как думаешь, {name} любит мелодрамы?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь смотреть фильмы дома?",
				},
				new String[] {
					"Угадай, {name} любит смотреть фильмы дома?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Увлекаешься спортом?",
				},
				new String[] {
					"По-твоему, {name}  увлекается спортом?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты куришь?",
				},
				new String[] {
					"Как ты думаешь, {name} курит?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты часто опаздываешь на работу?",
				},
				new String[] {
					"Угадай, {name} часто опаздывает на работу?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты в детстве мечтала стать космонавтом?",
					"Ты в детстве мечтал стать космонавтом?",
				},
				new String[] {
					"По-твоему, {name} в детстве мечтала стать космонавтом?",
					"По-твоему, {name} в детстве мечтал стать космонавтом?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Если ты увидишь красивого парня, у тебя улучшится настроение?",
					"Если ты увидишь красивую девушку, у тебя улучшится настроение?",
				},
				new String[] {
					"Если {name} увидит красивого парня, то у нее улучшится настроение?",
					"Если {name} увидит красивую девушку, то у него улучшится настроение?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты веришь в приметы?",
				},
				new String[] {
					"Как ты думаешь, {name} верит в приметы?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты собираешь плюшевых медведей?",
				},
				new String[] {
					"Угадай, {name} собирает плюшевых медведей?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты помнишь про все дни рождения друзей?",
				},
				new String[] {
					"Как ты думаешь, {name} помнит про все дни рождения друзей?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь смотреть на звезды?",
				},
				new String[] {
					"Как ты думаешь, {name} любит смотреть на звезды?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты следишь за распродажами в магазинах?",
				},
				new String[] {
					"По-твоему, {name} следит за распродажами в магазинах?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты спишь в голубенькой пижаме с розовыми слониками?",
				},
				new String[] {
					"По-твоему, {name} спит в голубенькой пижаме с розовыми слониками?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты часто online на ФотоСтране?",
				},
				new String[] {
					"Как думаешь, {name} часто online на ФотоСтране?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь кактусы?",
				},
				new String[] {
					"Как считаешь, {name} любит кактусы?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь ходить по магазинам?",
				},
				new String[] {
					"Как думаешь, {name} любит ходить по магазинам?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Если ты найдёшь чемодан с миллионом долларов, ты отдашь его в Бюро находок?",
				},
				new String[] {
					"Если {name} найдёт чемодан с миллионом долларов, она его отдаст в Бюро находок?",
					"Если {name} найдёт чемодан с миллионом долларов, он его отдаст в Бюро находок?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты разводишь в ванной крокодилов?",
				},
				new String[] {
					"По-твоему, {name} разводит в ванной крокодилов?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты хочешь побывать на необитаемом острове?",
				},
				new String[] {
					"Как думаешь, {name} хочет побывать на необитаемом острове?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты внимательно слушаешь прогноз погоды?",
				},
				new String[] {
					"Как думаешь, {name} внимательно слушает прогноз погоды?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь самостоятельно поменять лампочку?",
				},
				new String[] {
					"Как думаешь, {name} сможет самостоятельно поменять лампочку?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты ныряешь в прорубь зимой?",
				},
				new String[] {
					"По-твоему, {name} ныряет в прорубь зимой?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты когда-нибудь видела падающую звезду?",
					"Ты когда-нибудь видел падающую звезду?",
				},
				new String[] {
					"Угадай, {name} когда-нибудь видела падающую звезду?",
					"Угадай, {name} когда-нибудь видел падающую звезду?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты умеешь кататься на коньках?",
				},
				new String[] {
					"Как ты думаешь, {name} умеет кататься на коньках?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты умеешь вышивать крестиком?",
				},
				new String[] {
					"По-твоему, {name} умеет вышивать крестиком?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты помнишь теорему Пифагора?",
				},
				new String[] {
					"Как считаешь, {name} помнит теорему Пифагора?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты иногда мечтаешь снова стать маленькой?",
					"Ты иногда мечтаешь снова стать маленьким?",
				},
				new String[] {
					"{name} иногда мечтает снова стать маленькой?",
					"{name} иногда мечтает снова стать маленьким?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты смогла бы работать за полярным кругом?",
					"Ты смог бы работать за полярным кругом?",
				},
				new String[] {
					"Как ты думаешь, {name} смогла бы работать за полярным кругом?",
					"Как ты думаешь, {name} смог бы работать за полярным кругом?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты смогла бы на спор подстричься «под нолик»?",
					"Ты смог бы на спор подстричься «под нолик»?",
				},
				new String[] {
					"По-твоему, {name} смогла бы на спор подстричься «под нолик»?",
					"По-твоему, {name} смог бы на спор подстричься «под нолик»?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты когда-нибудь делала себе татуировки?",
					"Ты когда-нибудь делал себе татуировки?",
				},
				new String[] {
					"Угадай, {name} когда-нибудь делала себе татуировки?",
					"Угадай, {name} когда-нибудь делал себе татуировки?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты носишь пирсинг в носу?",
				},
				new String[] {
					"Как ты думаешь, {name} носит пирсинг в носу?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты ныряла когда-нибудь с аквалангом?",
					"Ты нырял когда-нибудь с аквалангом?",
				},
				new String[] {
					"Угадай, {name} ныряла когда-нибудь с аквалангом?",
					"Угадай, {name} нырял когда-нибудь с аквалангом?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты боишься пауков?",
				},
				new String[] {
					"Как ты думаешь, {name} боится пауков?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты в детстве боялась зубных врачей?",
					"Ты в детстве боялся зубных врачей?",
				},
				new String[] {
					"В детстве {name} боялась зубных врачей?",
					"В детстве {name} боялся зубных врачей?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты хранишь дома ненужные вещи?",
				},
				new String[] {
					"Хранит ли  {name} дома ненужные вещи?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты помнишь названия элементов таблицы Менделеева?",
				},
				new String[] {
					"По-твоему, {name} помнит названия элементов таблицы Менделеева?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты умеешь играть на гитаре?",
				},
				new String[] {
					"Как ты думаешь, {name} умеет играть на гитаре?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты хотела бы побывать в мавзолее Ленина?",
					"Ты хотел бы побывать в мавзолее Ленина?",
				},
				new String[] {
					"{name} хотела бы побывать в мавзолее Ленина?",
					"{name} хотел бы побывать в мавзолее Ленина?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты мечтаешь стать супергероем?",
				},
				new String[] {
					"Мечтает ли {name} стать супергероем?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь читать книги?",
				},
				new String[] {
					"Угадай, {name} прочитала много разных книг?",
					"Угадай, {name} прочитал много разных книг?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь картинг?",
				},
				new String[] {
					"Как думаешь, {name} любит картинг?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь играть в нинтендо?",
				},
				new String[] {
					"Как думаешь, {name} любит играть в нинтендо?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь играть на пианино?",
				},
				new String[] {
					"Как думаешь, {name}  любит играть на пианино?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь петь песни под гитару?",
				},
				new String[] {
					"Как думаешь, {name}  любит петь песни под гитару?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь полоть грядки на даче?",
				},
				new String[] {
					"Как думаешь, {name}  любит полоть грядки на даче?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь доставать других людей, в то время, когда они заняты?",
				},
				new String[] {
					"Как думаешь, {name}  любит доставать других людей, в то время, когда они заняты?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь собирать грибы?",
				},
				new String[] {
					"Как думаешь, {name}  любит собирать грибы?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь рыбачить?",
				},
				new String[] {
					"Как думаешь, {name}  любит рыбачить?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь играть в боулинг?",
				},
				new String[] {
					"Как думаешь, {name}  любит играть в боулинг?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты пересматриваешь альбом с детскими фотографиями?",
				},
				new String[] {
					" Как думаешь, {name}  пересматривает альбом с детскими фотографиями?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь убираться дома?",
				},
				new String[] {
					"Как думаешь, {name}  любит убираться дома?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь тусить с друзьями?",
				},
				new String[] {
					"Как думаешь, {name}  любит тусить с друзьями?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь ездить загород и купаться летом?",
				},
				new String[] {
					"Как думаешь, {name}  любит ездить загород и купаться летом?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь переписываться с друзьями до полуночи?",
				},
				new String[] {
					"Как думаешь, {name}  любит переписываться с друзьями до полуночи?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь бродить по улицам, если тебе нечего делать?",
				},
				new String[] {
					"Как думаешь, {name} любит бродить по улицам, если ей нечего делать?",
					"Как думаешь, {name} любит бродить по улицам, если ему нечего делать?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь сидеть на берегу реки, опустив ноги в воду?",
				},
				new String[] {
					"Как думаешь, {name}  любит сидеть на берегу реки, опустив ноги в воду?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь посещать музеи и выставки?",
				},
				new String[] {
					"Как думаешь, {name}  любит посещать музеи и выставки?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты коллекционируешь монеты?",
				},
				new String[] {
					"По-твоему, {name} коллекционирует монеты?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь рисовать узоры на запотевшем стекле?",
				},
				new String[] {
					"Как думаешь, {name}  любит рисовать узоры на запотевшем стекле?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь дуть на одуванчик, когда тот пушистый?",
				},
				new String[] {
					"Как думаешь, {name}  любит дуть на одуванчик, когда тот пушистый?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь косить траву?",
				},
				new String[] {
					"Как думаешь, {name}  любит косить траву?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь вставать рано по утрам?",
				},
				new String[] {
					"Как думаешь, {name}  любит вставать рано по утрам?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь пение птиц весной?",
				},
				new String[] {
					"Как думаешь, {name}  любит пение птиц весной?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь тягать штангу?",
				},
				new String[] {
					"Как думаешь, {name}  любит тягать штангу?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты пишешь стихи?",
				},
				new String[] {
					"Угадай, {name} пишет стихи?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь пускать кораблики по ручью?",
				},
				new String[] {
					"Угадай, {name}  любит пускать кораблики по ручью?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь карусели?",
				},
				new String[] {
					"Как ты думаешь, {name}  любит карусели?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь новогодние концерты по телевизору?",
				},
				new String[] {
					"По-твоему, {name} любит новогодние концерты по телевизору?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь петь песню &laquo;Ой, мороз, морооооз&raquo;?",
				},
				new String[] {
					"Ты считаешь, что {name} любит петь песню &laquo;Ой, мороз, морооооз&raquo;?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь горы?",
				},
				new String[] {
					"{name} любит горы?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты носишь контактные линзы?",
				},
				new String[] {
					"Как ты думаешь, {name} носит контактные линзы?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты предпочитаешь ездить только на дорогих машинах?",
				},
				new String[] {
					"По-твоему, {name} ездит только на дорогих машинах?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты часто нарушаешь правила дорожного движения?",
				},
				new String[] {
					"Угадай, {name} часто нарушает правила дорожного движения?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Если ты увидишь чёрную кошку, то перейдёшь на другую сторону дороги?",
				},
				new String[] {
					"Если {name} увидит чёрную кошку, она перейдёт на другую сторону дороги?",
					"Если {name} увидит чёрную кошку, он перейдёт на другую сторону дороги?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Если ты забудешь что-то дома, то ты обязательно за этим вернёшься?",
				},
				new String[] {
					"Когда {name} что-то забывает дома, она обязательно за этим возвращается?",
					"Когда {name} что-то забывает дома, он обязательно за этим возвращается?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты согласишься помочь незнакомому человеку?",
				},
				new String[] {
					"Согласится ли {name} помочь незнакомому человеку?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты страстный поклонник группы Queen?",
				},
				new String[] {
					"Как ты думаешь, {name} страстный поклонник группы Queen?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"У тебя дома много растений и цветов?",
				},
				new String[] {
					"По-твоему, {name} держит дома много растений и цветов?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты помнишь хотя бы одно стихотворение Пушкина наизусть?",
				},
				new String[] {
					"{name} помнит хотя бы одно стихотворение Пушкина наизусть?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты знаешь, где находится созвездие Орион?",
				},
				new String[] {
					"Как ты считаешь, {name} знает, где находится созвездие Орион?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты часто делаешь грамматические ошибки?",
				},
				new String[] {
					"{name} часто делает грамматические ошибки?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты хотела бы побывать на Луне?",
					"Ты хотел бы побывать на Луне?",
				},
				new String[] {
					"{name} хотела бы побывать на Луне?",
					"{name} хотел бы побывать на Луне?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты умеешь вязать крючком?",
				},
				new String[] {
					"Как ты считаешь, {name} умеет вязать крючком?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты мечтаешь стать знаменитой?",
					"Ты мечтаешь стать знаменитым?",
				},
				new String[] {
					"Мечтает ли {name} стать знаменитой?",
					"Мечтает ли {name} стать знаменитым?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь песни группы Abba?",
				},
				new String[] {
					"Любит ли {name} песни группы Abba?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты выигрывала когда-нибудь в лотерею?",
					"Ты выигрывал когда-нибудь в лотерею?",
				},
				new String[] {
					"Угадай, {name} выигрывала когда-нибудь в лотерею?",
					"Угадай, {name} выигрывал когда-нибудь в лотерею?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты наделена чувством юмора?",
					"Ты наделён чувством юмора?",
				},
				new String[] {
					"Как думаешь, {name} наделена чувством юмора?",
					"Как думаешь, {name} наделён чувством юмора?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"У тебя бывали когда-нибудь проблемы с алкоголем?",
				},
				new String[] {
					"Как думаешь, {name} имела когда-нибудь проблемы с алкоголем?",
					"Как думаешь, {name} имел когда-нибудь проблемы с алкоголем?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь домашних животных?",
				},
				new String[] {
					"Угадай, {name} любит домашних животных?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Для тебя важно иметь с партнёром общие интересы?",
				},
				new String[] {
					"Угадай, {name} считает важным иметь общие интересы с партнёром?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты смотришь &quot;Иронию судьбы&quot; каждый новый год?",
				},
				new String[] {
					"Угадай, {name} смотрит &quot;Иронию судьбы&quot; каждый новый год?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь делать интересные фотографии?",
				},
				new String[] {
					"{name} любит делать интересные фотографии?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Любишь путешествовать?",
				},
				new String[] {
					"{name} любит путешествовать?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты мечтаешь посетить Париж?",
				},
				new String[] {
					"{name} мечтает посетить Париж?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Любишь читать книги по психологии?",
				},
				new String[] {
					"{name} читает книги по психологии?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты стильно выглядишь на фото?",
				},
				new String[] {
					"Как ты считаешь, {name} стильно выглядит на фото?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты умеешь делать классные алкогольные коктейли?",
				},
				new String[] {
					"Как ты думаешь, {name} умеет делать классные алкогольные коктейли?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Стабильность и размеренность во всём, это про тебя?",
				},
				new String[] {
					"Угадай, {name} гарант стабильности и размеренности во всём?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь шумные вечеринки и дискотеки?",
				},
				new String[] {
					"Как ты думаешь, {name} любит шумные вечеринки и дискотеки?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты хочешь иметь собственный бизнес?",
				},
				new String[] {
					"Угадай, {name} хочет иметь собственный бизнес?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты умеешь плавать баттерфляем?",
				},
				new String[] {
					"Угадай, {name} умеет плавать баттерфляем?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты хочешь себе домашнее животное?",
				},
				new String[] {
					"Как ты думаешь, {name} хочет себе домашнее животное?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты в детстве часто плакала?",
					"Ты в детстве часто плакал?",
				},
				new String[] {
					"Как думаешь, {name} часто плакала в детстве?",
					"Как думаешь, {name} часто плакал в детстве?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты часто посещаешь спортзал?",
				},
				new String[] {
					"Угадай, {name} часто посещает спортзал?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты мечтаешь о новой машине?",
				},
				new String[] {
					"{name} мечтает о новой машине?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты умеешь танцевать?",
				},
				new String[] {
					"Угадай, {name} умеет танцевать?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты участвовала в конкурсе красоты?",
					"Ты участвовал в конкурсе красоты?",
				},
				new String[] {
					"Угадай, {name} участвовала в конкурсе красоты?",
					"Угадай, {name} участвовал в конкурсе красоты?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты часто играешь в азартные игры?",
				},
				new String[] {
					"По-твоему, {name} часто играет в азартные игры?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты часто просыпаешься вовремя без будильника?",
				},
				new String[] {
					"Угадай, {name} часто просыпается вовремя без будильника?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты хочешь прыгнуть с парашютом?",
				},
				new String[] {
					"Угадай, {name} хочет прыгнуть с парашютом?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Любишь быструю езду на машине?",
				},
				new String[] {
					"По-твоему, {name} любит быструю езду на машине?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты часто меняешь место работы?",
				},
				new String[] {
					"Как думаешь, {name} часто меняет место работы?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Любишь восточную музыку?",
				},
				new String[] {
					"Угадай, {name} любит восточную музыку?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь поспать?",
				},
				new String[] {
					"По-твоему, {name} любит поспать?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Любишь пешие прогулки по городу?",
				},
				new String[] {
					"Угадай, {name} любит пешие прогулки по городу?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты часто тратишь свободное время на работу, которая приносит дополнительную прибыль?",
				},
				new String[] {
					"Угадай, {name} часто тратит свободное время на работу, которая приносит дополнительную прибыль?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь ходить в театр?",
				},
				new String[] {
					"Угадай, {name} любит ходить в театр?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты хотела бы сняться в кино?",
					"Ты хотел бы сняться в кино?",
				},
				new String[] {
					"По-твоему, {name} хотела бы сняться в кино?",
					"По-твоему, {name} хотел бы сняться в кино?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь праздновать Рождество?",
				},
				new String[] {
					"По-твоему, {name} любит праздновать Рождество?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"У тебя есть аллергия на шерсть домашних животных?",
				},
				new String[] {
					"По-твоему, {name} имеет аллергию на шерсть домашних животных?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты делаешь зарядку по утрам?",
				},
				new String[] {
					"Угадай, {name} делает зарядку по утрам?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты часто слушаешь музыку?",
				},
				new String[] {
					"Как думаешь, {name} часто слушает музыку?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Тебя интересует мир моды?",
				},
				new String[] {
					"Угадай, {name} интересуется миром моды?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Тебе нравится проводить свободное время в спортзале?",
				},
				new String[] {
					"По-твоему, {name} любит проводить свободное время в спортзале?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты занимаешься самообразованием?",
				},
				new String[] {
					"Угадай, {name} занимается самообразованием?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"У тебя были серьёзные отношения после знакомства на Фотостране?",
				},
				new String[] {
					"Угадай, после знакомства на Фотостране {name} была в серьёзных отношениях?",
					"Угадай, после знакомства на Фотостране {name} был в серьёзных отношениях?",
				},
			}),
			new OneVariant(new String[] {
				"Ты любишь читать романы?",
			}),
			new OneVariant(new String[] {
				"Ты веришь в гороскопы?",
			}),
			new OneVariant(new String[] {
				"Ты любишь фильмы ужасов?",
			}),
			new OneVariant(new String[] {
				"Ты ходишь на концерты?",
			}),
			new OneVariant(new String[] {
				"Ты занимаешься благотворительностью?",
			}),
			new OneVariant(new String[] {
				"Ты ходишь на театральные премьеры?",
			}),
			new OneVariant(new String[] {
				"Ты много времени проводишь в интернете?",
			}),
			new OneVariant(new String[] {
				"Ты интересуешься политикой?",
			}),
			new OneVariant(new String[] {
				"Ты умеешь играть на гитаре?",
			}),
			new OneVariant(new String[] {
				"Ты занимаешься йогой?",
			}),
			new OneVariant(new String[] {
				"Любишь ходить по барам и ночным клубам?",
			}),
			new OneVariant(new String[] {
				"Умеешь кататься на роликах?",
			}),
			new OneVariant(new String[] {
				"Ты интересуешься искусством?",
			}),
			new OneVariant(new String[] {
				"Любишь настольные игры и паззлы?",
			}),
			new OneVariant(new String[] {
				"Тебе нравится красное вино?",
			}),
			new OneVariant(new String[] {
				"Ты любишь ходить по магазинам?",
			}),
			new OneVariant(new String[] {
				"Любишь петь в караоке?",
			}),
			new OneVariant(new String[] {
				"Ты собираешь магнитики на холодильник из разных стран?",
			}),
			new OneVariant(new String[] {
				"Ты веришь в судьбу?",
			}),
			new OneVariant(new String[] {
				"У тебя есть кот?",
				"Как ты считаешь, есть ли у неё кот?",
			}),
			new OneVariant(new String[] {
				"Ты хорошо плаваешь?",
				"Угадай, она умеет хорошо плавать?",
			}),
			new OneVariant(new String[] {
				"Ты мечтаешь завести хомячка?",
				"Мечтает ли она завести хомячка?",
			}),
			new OneVariant(new String[] {
				"Ты любишь смотреть фильмы ужасов?",
				"Думаешь, она любит смотреть фильмы ужасов?",
			}),
			new OneVariant(new String[] {
				"Ты готова провести выходные в огороде?",
				"Готова ли она провести выходные в огороде?",
			}),
			new OneVariant(new String[] {
				"Ты умеешь готовить блинчики и оладушки?",
				"Умеет ли она готовить блинчики и оладушки?",
			}),
			new OneVariant(new String[] {
				"Ты умеешь вышивать крестиком?",
				"Как думаешь, она умеет вышивать крестиком?",
			}),
			new OneVariant(new String[] {
				"Ты знаешь преимущество переднеприводных авто перед заднеприводными?",
				"Знает ли она преимущества переднеприводных авто перед заднеприводными?",
			}),
			new OneVariant(new String[] {
				"Ты посещаешь театральные премьеры сезона?",
				"Посещает ли она театральные премьеры сезона?",
			}),
			new OneVariant(new String[] {
				"Ты сидишь целыми днями в интернете?",
				"Как ты считаешь, сидит ли она целыми днями в интернете?",
			}),
			new OneVariant(new String[] {
				"У тебя есть кулинарные способности?",
				"Имеются ли у неё кулинарные способности?",
			}),
			new OneVariant(new String[] {
				"Ты смогла бы сама себе сшить платье?",
				"Как ты считаешь, смогла бы она сама сшить себе платье?",
			}),
			new OneVariant(new String[] {
				"Ты следишь за последними тенденциями моды?",
				"Следит ли она за последними тенденциями моды?",
			}),
			new OneVariant(new String[] {
				"Ты любишь гоночные автомобили?",
				"Думаешь, она любит гоночные автомобили?",
			}),
			new OneVariant(new String[] {
				"Ты читаешь книги по психологии семейной жизни?",
				"Думаешь, она читает книги по психологии семейной жизни?",
			}),
			new OneVariant(new String[] {
				"Ты умеешь разговаривать на нескольких иностранных языках?",
				"Как думаешь, разговаривает ли она на нескольких иностранных языках?",
			}),
			new OneVariant(new String[] {
				"Ты занималась художественной гимнастикой?",
				"Угадай, она занималась художественной гимнастикой?",
			}),
			new OneVariant(new String[] {
				"Ты любишь поваляться на пляже с журналом и коктейльчиком?",
				"Любит ли она поваляться на пляже с журналом и коктейльчиком?",
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты смотришь бразильские сериалы?",
				},
				new String[] {
					"Угадай, {name} смотрит бразильские сериалы?",
				},
			}),
			new OneVariant(new String[] {
				"Ты любишь, когда мужчина помогает на кухне тебе?",
				"Думаешь, она любит, когда мужчина помогает на кухне ей?",
			}),
			new OneVariant(new String[] {
				"Ты умеешь производить впечатление на мужчин?",
				"Думаешь, она умеет произвести впечатление на мужчин?",
			}),
			new OneVariant(new String[] {
				"Ты сможешь поддержать светскую беседу?",
				"Сумеет ли она поддержать светскую беседу?",
			}),
			new OneVariant(new String[] {
				"Ты любишь яркий макияж?",
				"Угадай, {string} любит яркий макияж?",
			}),
			new OneVariant(new String[] {
				"Угадай, {string} ведёт здоровый образ жизни?",
				"Ты ведёшь здоровый образ жизни?",
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты пьёшь чай с сахаром?",
				},
				new String[] {
					"Как думаешь, {name} пьёт чай с сахаром?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь пускать мыльные пузыри?",
				},
				new String[] {
					"Как думаешь, {name} любит пускать мыльные пузыри?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Тебе нравится разгадывать загадки?",
				},
				new String[] {
					"Как думаешь, {name} любит разгадывать загадки?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты сладкоежка?",
				},
				new String[] {
					"Как думаешь, {name} сладкоежка?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты умеешь шевелить ушами?",
				},
				new String[] {
					"Как думаешь, {name} умеет шевелить ушами?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты когда-нибудь делала сама ремонт в квартире?",
					"Ты когда-нибудь делал сам ремонт в квартире?",
				},
				new String[] {
					"Думаешь, {name} когда-нибудь делала сама ремонт в квартире?",
					"Думаешь, {name} когда-нибудь делал сам ремонт в квартире?",
				},
			}),
			new OneVariant(new String[] {
				"Ты любишь принимать ванну с пеной?",
				"Как думаешь, {string} любит принимать ванну с пеной?",
			}),
			new OneVariant(new String[] {
				"Любишь книги и фильмы про вампиров?",
				"Как считаешь, {string} любит книги и фильмы про вампиров?",
			}),
			new OneVariant(new String[] {
				"Как считаешь, {string} может постоять за любимую девушку?",
				"Ты можешь постоять за любимую девушку?",
			}),
			new OneVariant(new String[] {
				"Как думаешь, {string} может подтянуться на турнике 30 раз?",
				"Ты можешь подтянуться на турнике 30 раз?",
			}),
			new OneVariant(new String[] {
				"Как думаешь, {string} служил в армии?",
				"Ты служил в армии?",
			}),
			new OneVariant(new String[] {
				"Ты можешь потратить все деньги на новые туфли?",
				"Как думаешь, {string} может потратить все деньги на новые туфли?",
			}),
			new OneVariant(new String[] {
				"Для тебя «красиво» важнее, чем «удобно»?",
				"Думаешь, {string} предпочитает красоту удобству?",
			}),
			new OneVariant(new String[] {
				"Как думаешь, {string} может починить протекающий кран?",
				"Ты можешь починить протекающий кран?",
			}),
			new OneVariant(new String[] {
				"Ты печёшь пироги и торты?",
				"Думаешь, {string} печёт пироги и торты?",
			}),
			new OneVariant(new String[] {
				"Ты смотрела в детстве «Спокойной ночи, малыши»?",
				"Ты смотрел в детстве «Спокойной ночи, малыши»?",
			}),
			new OneVariant(new String[] {
				"Умеешь играть в большой теннис?",
			}),
			new OneVariant(new String[] {
				"Ты умеешь играть в шахматы?",
			}),
			new OneVariant(new String[] {
				"Ты любишь играть в снежки?",
			}),
			new OneVariant(new String[] {
				"Ты знаешь, кто убил Лору Палмер?",
			}),
			new OneVariant(new String[] {
				"Тебе нравится читать детективы?",
			}),
			new OneVariant(new String[] {
				"Ты любишь экстремальные виды спорта?",
			}),
			new OneVariant(new String[] {
				"Ты сама наряжаешь ёлку на Новый год?",
				"Ты сам наряжаешь ёлку на Новый год?",
			}),
			new OneVariant(new String[] {
				"Ты когда-нибудь играла в карты на раздевание?",
				"Ты когда-нибудь играл в карты на раздевание?",
			}),
			new OneVariant(new String[] {
				"Ты ведёшь дневник?",
			}),
			new OneVariant(new String[] {
				"Умеешь кататься на лыжах?",
			}),
			new OneVariant(new String[] {
				"Ты любишь нырять, когда купаешься?",
			}),
			new OneVariant(new String[] {
				"Тебе нравится кто-нибудь из отечественных исполнителей?",
			}),
			new OneVariant(new String[] {
				"Любишь смотреть, как солнце садится в море?",
			}),
			new OneVariant(new String[] {
				"Ты умеешь варить борщ?",
				"Думаешь, {string} умеет варить борщ?",
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь заплакать от счастья?",
				},
				new String[] {
					"Как ты думаешь, {name} может заплакать от счастья?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты считаешь себя добрым человеком?",
				},
				new String[] {
					"Ты считаешь, что {name} добрый человек?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты равнодушный человек?",
				},
				new String[] {
					"Можно ли сказать, что {name} равнодушный человек?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Можно ли сказать, что в душе ты всё ещё ребёнок?",
				},
				new String[] {
					"Как ты думаешь, {name} в душе всё ещё ребёнок?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты считаешь себя неисправимым романтиком и оптимистом?",
				},
				new String[] {
					"Как ты считаешь, {name} - неисправимый романтик и оптимист?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты скромный человек?",
				},
				new String[] {
					"{name} скромный человек?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь обмануть лучшего друга?",
				},
				new String[] {
					"Может ли {name} обмануть лучшего друга?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты веришь в любовь с первого взгляда?",
				},
				new String[] {
					"Как ты думаешь, {name} верит в любовь с первого взгляда?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты считаешь себя интересным собеседником?",
				},
				new String[] {
					"{name} считает себя интересным собеседником?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь посплетничать?",
				},
				new String[] {
					"Как ты считаешь, {name} - сплетница?",
					"Как ты считаешь, {name} - сплетник?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты общительный человек?",
				},
				new String[] {
					"Как ты думаешь, {name} общительный человек?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты считаешь себя счастливым человеком?",
				},
				new String[] {
					"По-твоему, {name} считает себя счастливым человеком?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты подкармливаешь бездомных животных?",
				},
				new String[] {
					"{name} подкармливает бездомных животных?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь часами болтать по телефону?",
				},
				new String[] {
					"Как ты думаешь, {name} может часами болтать по телефону?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты краснеешь, когда смущаешься?",
				},
				new String[] {
					"По-твоему, {name} краснеет, когда смущается?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь честно признаться, что совершила глупость?",
					"Ты можешь честно признаться, что совершил глупость?",
				},
				new String[] {
					"Может ли {name} честно признаться, что совершила глупость?",
					"Может ли {name} честно признаться, что совершил глупость?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты скрываешь много секретов от друзей?",
				},
				new String[] {
					"Как ты думаешь, {name} скрывает много секретов?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты пунктуальный человек?",
				},
				new String[] {
					"По-твоему, {name} пунктуальный человек?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты серьёзна только в работе?",
					"Ты серьёзен только в работе?",
				},
				new String[] {
					"Как ты думаешь, {name} серьёзна только в работе?",
					"Как ты думаешь, {name} серьёзен только в работе?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь гулять всю ночь до утра?",
				},
				new String[] {
					"Как ты считаешь, {name} может гулять всю ночь до утра?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты вспыльчивый человек?",
				},
				new String[] {
					"По-твоему, {name} вспыльчивый человек?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты считаешь себя особенной?",
					"Ты считаешь себя особенным?",
				},
				new String[] {
					"Угадай, {name} считает себя особенной?",
					"Угадай, {name} считает себя особенным?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты часто скрываешь правду?",
				},
				new String[] {
					"Как ты думаешь, {name} часто скрывает правду?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь фантазировать?",
				},
				new String[] {
					"Как ты считаешь, {name} любит фантазировать?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты наглый человек?",
				},
				new String[] {
					"По-твоему, {name} наглый человек?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь пожелать кому-нибудь зла?",
				},
				new String[] {
					"Угадай, {name} может пожелать кому-то зла?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь учиться?",
				},
				new String[] {
					"Как ты думаешь, {name} любит учиться?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь часами сидеть на подоконнике и смотреть на дождь?",
				},
				new String[] {
					"По-твоему, {name} может часами сидеть на подоконнике и смотреть на дождь?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты считаешь себя эмоциональным человеком?",
				},
				new String[] {
					"По-твоему, {name} эмоциональный человек?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь азартные игры?",
				},
				new String[] {
					"Угадай, {name} любит азартные игры?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты держишь свои обещания?",
				},
				new String[] {
					"Как ты думаешь, {name} обязательно выполняет то, что обещала?",
					"Как ты думаешь, {name} обязательно выполняет то, что обещал?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь обидеть друга?",
				},
				new String[] {
					"Как ты считаешь, {name} может обидеть друга?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты пользуешься успехом у парней?",
					"Ты пользуешься успехом у девушек?",
				},
				new String[] {
					"По-твоему, {name} пользуется успехом у парней?",
					"По-твоему, {name} пользуется успехом у девушек?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты часто повышаешь на кого-то голос?",
				},
				new String[] {
					"Угадай, {name}  часто повышает голос?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты подслушиваешь чужие разговоры?",
				},
				new String[] {
					"Как ты думаешь, {name} подслушивает чужие разговоры?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь дать ценный совет?",
				},
				new String[] {
					"Как ты считаешь, {name} может дать ценный совет?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты считаешь себя позитивным человеком?",
				},
				new String[] {
					"{name} считает себя позитивным человеком?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"У тебя есть какое-нибудь хобби?",
				},
				new String[] {
					"По-твоему, {name} увлекается чем-нибудь?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Тебя можно назвать наглой, но уверенной в себе?",
					"Тебя можно назвать наглым, но уверенным в себе?",
				},
				new String[] {
					"По-твоему, {name} - наглая, но уверенная в себе?",
					"По-твоему, {name} - наглый, но уверенный в себе?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты сплетничаешь о парнях в кругу подруг?",
					"Ты сплетничаешь о девчонках в кругу друзей?",
				},
				new String[] {
					"По-твоему, {name} сплетничает о парнях в кругу подруг?",
					"По-твоему, {name} сплетничает о девчонках в кругу друзей?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь часами разговаривать по телефону?",
				},
				new String[] {
					"Как ты думаешь, {name} может часами разговаривать по телефону?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты относишься к людям, про которых говорят &laquo;врёт и не краснеет&raquo;?",
				},
				new String[] {
					"{name} относится к тому типу людей, что врут и не краснеют?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты представляешь себя суперзвездой перед сном?",
				},
				new String[] {
					"Угадай, {name} представляет себя суперзвездой перед сном?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты знаешь, как по-французски звучит «Я тебя люблю»?",
				},
				new String[] {
					"Знает ли {name}, как по-французски звучит «Я тебя люблю»?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты больше любишь дарить подарки, чем получать?",
				},
				new String[] {
					"{name} больше любит дарить подарки, чем получать?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты станешь ввязываться в драку с обидчиком?",
				},
				new String[] {
					"Станет ли {name} ввязываться в драку с обидчиком?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты больше любишь делать комплименты, чем получать?",
				},
				new String[] {
					"Как ты считаешь, {name} больше любит делать комплименты, чем получать?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты умеешь танцевать вальс?",
				},
				new String[] {
					"Умеет ли {name} танцевать вальс?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь уехать в отпуск без своей половинки?",
				},
				new String[] {
					"Может ли {name} уехать в отпуск без своей половинки?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты умеешь хранить чужие секреты?",
				},
				new String[] {
					"Как ты думаешь, {name} умеет хранить чужие секреты?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты влюблялась когда-нибудь с первого взгляда?",
					"Ты влюблялся когда-нибудь с первого взгляда?",
				},
				new String[] {
					"Как ты думаешь, {name} когда-нибудь влюблялась с первого взгляда?",
					"Как ты думаешь, {name} когда-нибудь влюблялся с первого взгляда?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты решительный человек?",
				},
				new String[] {
					"Как ты думаешь, {name} решительный человек?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты могла бы стать шпионом?",
					"Ты мог бы стать шпионом?",
				},
				new String[] {
					"Как ты думаешь, {name} могла бы стать шпионом?",
					"Как ты думаешь, {name} мог бы стать шпионом?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты стесняешься выступать перед публикой?",
				},
				new String[] {
					"Как ты думаешь, стесняется ли {name} выступать перед публикой?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты злопамятная?",
					"Ты злопамятный?",
				},
				new String[] {
					"Как ты думаешь, {name} злопамятная?",
					"Как ты думаешь, {name} злопамятный?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты способна на риск?",
					"Ты способен на риск?",
				},
				new String[] {
					"Как ты думаешь, {name} способна на риск?",
					"Как ты думаешь, {name} способен на риск?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты боишься высоты?",
				},
				new String[] {
					"Как ты думаешь, {name} боится высоты?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь зло пошутить?",
				},
				new String[] {
					"Как ты думаешь, {name} умеет зло шутить?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь чёрный юмор?",
				},
				new String[] {
					"Любит ли {name} чёрный юмор?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты ревнивый человек?",
				},
				new String[] {
					"Ревнивый ли {name} человек?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты принципиальный человек?",
				},
				new String[] {
					"{name} принципиальный человек?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты способна первой пойти на уступки во время сильной ссоры?",
					"Ты способен первым пойти на уступки во время сильной ссоры?",
				},
				new String[] {
					"{name} способна первой пойти на уступки во время сильной ссоры?",
					"{name} способен первым пойти на уступки во время сильной ссоры?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты внимательна к мелочам?",
					"Ты внимателен к мелочам?",
				},
				new String[] {
					"Как ты думаешь, {name} внимательна к мелочам?",
					"Как ты думаешь, {name} внимателен к мелочам?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты стесняешься знакомиться на улице?",
				},
				new String[] {
					"{name} стесняется знакомиться на улице?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты имеешь вредные привычки, от которых тебе хотелось бы избавиться?",
				},
				new String[] {
					"{name} имеет вредные привычки, от которых она хочет избавиться?",
					"{name} имеет вредные привычки, от которых он хочет избавиться?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты пунктуальный человек?",
				},
				new String[] {
					"По-твоему, {name} пунктуальный человек?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты часто улыбаешься?",
				},
				new String[] {
					"Как думаешь, {name} часто улыбается?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Сможешь ли ты бросить всё и уехать в жаркие страны?",
				},
				new String[] {
					"Сможет ли {name} бросить всё и уехать в жаркие страны?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты смогла бы прийти на свидание без цветов?",
					"Ты смог бы прийти на свидание без цветов?",
				},
				new String[] {
					"Как ты думаешь, {name} смогла бы прийти на свидание без цветов?",
					"Как ты думаешь, {name} смог бы прийти на свидание без цветов?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты смогла бы пригласить вторую половинку прогуляться по крышам?",
					"Ты смог бы пригласить вторую половинку прогуляться по крышам?",
				},
				new String[] {
					"Как ты думаешь, {name} смогла бы пригласить вторую половинку прогуляться по крышам?",
					"Как ты думаешь, {name} смог бы пригласить вторую половинку прогуляться по крышам?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты способна ухаживать за своим парнем, когда тот болеет?",
					"Ты способен ухаживать за своей девушкой, когда та болеет?",
				},
				new String[] {
					"Как ты думаешь, {name} способна ухаживать за своим парнем, когда тот болеет?",
					"Как ты думаешь, {name} способен ухаживать за своей девушкой, когда та болеет?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь закрывать глаза на все недостатки, если любишь?",
				},
				new String[] {
					"Как ты думаешь, {name} может закрывать глаза на все недостатки, если любит?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты готова ради любимого человека прибраться в комнате?",
					"Ты готов ради любимого человека прибраться в комнате?",
				},
				new String[] {
					"Как ты думаешь, {name} готова ради любимого человека прибраться в комнате?",
					"Как ты думаешь, {name} готов ради любимого человека прибраться в комнате?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты готова пылесосить и выносить мусор, только чтобы твоя вторая половинка не ругалась?",
					"Ты готов пылесосить и выносить мусор, только чтобы твоя вторая половинка не ругалась?",
				},
				new String[] {
					"Как ты думаешь, {name} готова пылесосить и выносить мусор, только чтобы её вторая половинка не ругалась?",
					"Как ты думаешь, {name} готов пылесосить и выносить мусор, только чтобы его вторая половинка не ругалась?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты душа любой компании?",
				},
				new String[] {
					"Угадай, {name} может быть душой компании?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты предпочитаешь практичности романтику?",
				},
				new String[] {
					"Угадай, {name} предпочитает практичности романтику?",
				},
			}),
			new OneVariant(new String[] {
				"Должен ли быть твой партнёр умным?",
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты практичный человек?",
				},
				new String[] {
					"{name} практичный человек?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"У тебя очаровательная улыбка?",
				},
				new String[] {
					"{name} обладает очаровательной улыбкой?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты реалист?",
				},
				new String[] {
					"{name} реалист?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты оптимист?",
				},
				new String[] {
					"{name} оптимист?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты уделяешь много внимания деталям в любом деле?",
				},
				new String[] {
					"Угадай, {name} уделяет много внимания деталям в любом деле?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь рискнуть жизнью ради любимого человека?",
				},
				new String[] {
					"{name} может рискнуть жизнью ради любимого человека?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты настойчива в достижении поставленной цели?",
					"Ты настойчив в достижении поставленной цели?",
				},
				new String[] {
					"{name} настойчива в достижении поставленной цели?",
					"{name} настойчив в достижении поставленной цели?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты взыскательна к себе?",
					"Ты взыскателен к себе?",
				},
				new String[] {
					"{name} взыскательна к себе?",
					"{name} взыскателен к себе?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Должен ли быть твой партнёр умным?",
				},
				new String[] {
					"Как ты думаешь, {name} считает, что партнёр обязательно должен быть умным?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты готова солгать во имя добра?",
					"Ты готов солгать во имя добра?",
				},
				new String[] {
					"Угадай, {name} готова солгать во имя добра?",
					"Угадай, {name} готов солгать во имя добра?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты часто меняешь свои планы в последний момент?",
				},
				new String[] {
					"Угадай, {name} часто меняет свои планы в последний момент?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты боишься стоматолога?",
				},
				new String[] {
					"Угадай, {name} боится стоматолога?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты поёшь в душе?",
				},
				new String[] {
					"Угадай, {name} поёт в душе?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь проводить выходные, валяясь весь день в постели?",
				},
				new String[] {
					"Угадай, {name} любит проводить выходные, валяясь весь день в постели?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты быстро забываешь обиды?",
				},
				new String[] {
					"Как ты думаешь, {name} быстро забывает обиды?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты часто улыбаешься просто так?",
				},
				new String[] {
					"Угадай, {name} часто улыбается просто так?",
				},
			}),
			new OneVariant(new String[] {
				"В тебе есть терпимость к ошибкам окружающих?",
			}),
			new OneVariant(new String[] {
				"Ты умеешь сдерживать свои эмоции?",
			}),
			new OneVariant(new String[] {
				"Тебе можно доверить секрет?",
			}),
			new OneVariant(new String[] {
				"Ты умеешь чувствовать настроение других людей?",
			}),
			new OneVariant(new String[] {
				"Ты веришь в чудеса?",
			}),
			new OneVariant(new String[] {
				"Ты сможешь прожить неделю в одиночестве на необитаемом острове?",
			}),
			new OneVariant(new String[] {
				"Ты ладишь с соседями по дому?",
			}),
			new OneVariant(new String[] {
				"Важен ли для тебя порядок на рабочем месте?",
			}),
			new OneVariant(new String[] {
				"Ты часто задумываешься о своём здоровье?",
			}),
			new OneVariant(new String[] {
				"Ты готова что-нибудь продать важное и дорогое тебе ради путешествия в экзотическую страну?",
				"Ты готов что-нибудь продать важное и дорогое тебе ради путешествия в экзотическую страну?",
			}),
			new OneVariant(new String[] {
				"Ты можешь одолжить денег друзьям?",
			}),
			new OneVariant(new String[] {
				"Ты умеешь улаживать конфликты?",
			}),
			new OneVariant(new String[] {
				"Ты сможешь перевести конфликт в шутку?",
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь читать женские романы?",
				},
				new String[] {
					"Как ты думаешь, {name} любит читать женские романы?",
				},
			}),
			new OneVariant(new String[] {
				"Ты веришь в гороскопы?",
				"Как думаешь, верит ли она в гороскопы?",
			}),
			new OneVariant(new String[] {
				"Ты спишь с мягкой игрушкой?",
				"Думаешь, она до сих пор спит с мягкой игрушкой?",
			}),
			new OneVariant(new String[] {
				"Ты веришь в предсказания?",
				"Думаешь, она верит в предсказания?",
			}),
			new OneVariant(new String[] {
				"Ты можешь бесконечно болтать по телефону с подругами?",
				"Может ли она бесконечно болтать по телефону с подругами?",
			}),
			new OneVariant(new String[] {
				"Ты любишь быстро ездить на машине и нарушать ПДД?",
				"Думаешь, она любит превышать скоростные ограничения?",
			}),
			new OneVariant(new String[] {
				"Ты интересуешься гаданием, астрологией или гороскопами?",
				"Считаешь, она интересуется гаданием, астрологией или гороскопами?",
			}),
			new OneVariant(new String[] {
				"Ты часто накручиваешь себя по пустякам?",
				"Как ты думаешь, склонна ли она накручивать себя по пустякам?",
			}),
			new OneVariant(new String[] {
				"Ты часто чувствуешь себя незащищённой?",
				"Как ты думаешь, она часто чувствует себя незащищённой?",
			}),
			new OneVariant(new String[] {
				"Ты доверяешь своей интуиции?",
				"Как ты считаешь, она доверяет своей интуиции?",
			}),
			new OneVariant(new String[] {
				"Ты упрямая?",
				"Как ты считаешь, упряма ли она?",
			}),
			new OneVariant(new String[] {
				"Ты чересчур впечатлительная?",
				"Как ты думаешь, {string} чересчур впечатлительная?",
			}),
			new OneVariant(new String[] {
				"Ты часто бываешь эгоистичной?",
				"Как ты думаешь, она бывает эгоистичной?",
			}),
			new OneVariant(new String[] {
				"Ты часто плачешь по пустякам?",
				"Угадай, {string} часто плачет по пустякам?",
			}),
			new OneVariant(new String[] {
				"Как ты думаешь, {string} обидчивый?",
				"Ты обидчив?",
			}),
			new OneVariant(new String[] {
				"Как ты считаешь, любит ли он всё систематизировать и раскладывать по полочкам?",
				"Ты любишь всё систематизировать и раскладывать по полочкам?",
			}),
			new OneVariant(new String[] {
				"Как ты считаешь, важен ли для него порядок на рабочем столе?",
				"Для тебя важен порядок на рабочем столе?",
			}),
			new OneVariant(new String[] {
				"Как ты думаешь, бывает ли он иногда несдержанным?",
				"Ты бываешь несдержанным?",
			}),
			new OneVariant(new String[] {
				"Как ты думаешь, ему подходит роль руководителя?",
				"Тебе подходит роль руководителя?",
			}),
			new OneVariant(new String[] {
				"Угадай, {string} умеет рассказывать анекдоты и смешные истории?",
				"Умеешь рассказывать анекдоты и смешные истории?",
			}),
			new OneVariant(new String[] {
				"Как ты думаешь,он всегда готов одолжить друзьям денег?",
				"Ты всегда готов одолжить друзьям денег?",
			}),
			new OneVariant(new String[] {
				"У тебя часто бывают перепады настроения?",
				"Думаешь, {string} часто испытывает перепады настроения?",
			}),
			new OneVariant(new String[] {
				"Как думаешь, на него можно положиться?",
				"На тебя можно положиться?",
			}),
			new OneVariant(new String[] {
				"Думаешь, {string} считает всех блондинок глупыми?",
				"Ты считаешь блондинок глупыми?",
			}),
			new OneVariant(new String[] {
				"Ты много времени уделяешь своей внешности?",
				"Думаешь, {string} много времени уделяет своей внешности?",
			}),
			new OneVariant(new String[] {
				"Тебя можно назвать феминисткой?",
				"По-твоему, {string} - феминистка?",
			}),
			new OneVariant(new String[] {
				"Думаешь, {string} считает женскую логику абсурдной?",
				"Ты считаешь женскую логику абсурдной?",
			}),
			new OneVariant(new String[] {
				"Думаешь, {string} больше говорит, чем делает?",
				"Можно ли сказать, что ты больше говоришь, чем делаешь?",
			}),
			new OneVariant(new String[] {
				"Тебя можно назвать болтушкой?",
				"Думаешь, {string} болтушка?",
			}),
			new OneVariant(new String[] {
				"Тебя можно назвать адреналиновым наркоманом?",
			}),
			new OneVariant(new String[] {
				"Ты часто впадаешь в депрессию?",
			}),
			new OneVariant(new String[] {
				"Ты можешь разбить телефон после неприятного разговора?",
			}),
			new OneVariant(new String[] {
				"Ты тяжело переживала переходный возраст?",
				"Ты тяжело переживал переходный возраст?",
			}),
			new OneVariant(new String[] {
				"Часто ли ты не берёшь трубку, когда не хочешь разговаривать с человеком?",
			}),
			new OneVariant(new String[] {
				"Тебя можно назвать непоседой?",
			}),
			new OneVariant(new String[] {
				"Ты умеешь делать несколько дел одновременно?",
			}),
			new OneVariant(new String[] {
				"Тебя легко отвлечь от важного дела?",
			}),
			new OneVariant(new String[] {
				"Ты легко меняешь свою точку зрения?",
			}),
			new OneVariant(new String[] {
				"Ты легко приспосабливаешься к непривычным условиям?",
			}),
			new OneVariant(new String[] {
				"Ты любишь сюрпризы?",
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь испортить настроение окружающим, если твой день не задался?",
				},
				new String[] {
					"Как думаешь, {name} может испортить настроение окружающим, если её день не задался?",
					"Как думаешь, {name} может испортить настроение окружающим, если его день не задался?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь приключения?",
				},
				new String[] {
					"Думаешь, {name} любит приключения?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты часто споришь из-за ерунды?",
				},
				new String[] {
					"Думаешь, {name} часто спорит из-за ерунды?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты когда-нибудь хотела обратиться за помощью к психологу?",
					"Ты когда-нибудь хотел обратиться за помощью к психологу?",
				},
				new String[] {
					"Думаешь, {name} когда-нибудь хотела обратиться за помощью к психологу?",
					"Думаешь, {name} когда-нибудь хотел обратиться за помощью к психологу?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты часто разговариваешь сама с собой?",
					"Ты часто разговариваешь сам с собой?",
				},
				new String[] {
					"Думаешь, {name} часто разговаривает сама с собой?",
					"Думаешь, {name} часто разговаривает сам с собой?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты жалеешь о сделанном?",
				},
				new String[] {
					"Думаешь, {name} часто жалеет о сделанном?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Тебя можно назвать терпеливым человеком?",
				},
				new String[] {
					"Думаешь, {name} можно назвать терпеливым человеком?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты могла бы отобрать у ребёнка конфетку?",
					"Ты мог бы отобрать у ребёнка конфетку?",
				},
				new String[] {
					"Думаешь, {name} могла бы отобрать у ребёнка конфетку?",
					"Думаешь, {name} мог бы отобрать у ребёнка конфетку?",
				},
			}),
			new OneVariant(new String[] {
				"Думаешь, {string} - эгоист?",
				"Ты эгоист?",
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь изменить своей половинке?",
				},
				new String[] {
					"{name} может изменить своей половинке?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты готова совершить подвиг ради любимого человека?",
					"Ты готов совершить подвиг ради любимого человека?",
				},
				new String[] {
					"Может ли {name} совершить подвиг ради любимого человека?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Если {name} пригласит тебя на свидание, ты согласишься?",
				},
				new String[] {
					"Согласится ли {name} пойти с тобой на свидание?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты стала бы встречаться с парнем ради денег?",
					"Ты стал бы встречаться с девушкой ради денег?",
				},
				new String[] {
					"{name} стала бы встречаться с парнем ради денег?",
					"{name} стал бы встречаться с девушкой ради денег?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты смогла бы опоздать на первое свидание?",
					"Ты смог бы опоздать на первое свидание?",
				},
				new String[] {
					"Как ты думаешь, {name} смогла бы опоздать на первое свидание?",
					"Как ты думаешь, {name} смог бы опоздать на первое свидание?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь флиртовать?",
				},
				new String[] {
					"{name} любит флиртовать?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь устроить скандал в ресторане?",
				},
				new String[] {
					"Может ли {name} устроить скандал в ресторане?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь первой признаться в любви?",
					"Ты можешь первым признаться в любви?",
				},
				new String[] {
					"Может ли {name} первой признаться в любви?",
					"Может ли {name} первым признаться в любви?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты часто обещаешь достать звезду с неба?",
				},
				new String[] {
					"Часто ли {name} обещает достать звезду с неба?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты скорее предпочтёшь тихий отдых вдвоём, чем шумную компанию?",
				},
				new String[] {
					"{name} скорее предпочтёт тихий отдых вдвоём, чем шумную компанию?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты волнуешься, когда идёшь на первое свидание?",
				},
				new String[] {
					"По-твоему, {name} волнуется, когда идёт на первое свидание?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь романтичные свидания?",
				},
				new String[] {
					"По-твоему, {name} любит романтичные свидания?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты хочешь иметь много детей?",
				},
				new String[] {
					"Как ты думаешь, {name} хочет иметь много детей?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты способна пойти на преступление ради любви?",
					"Ты способен пойти на преступление ради любви?",
				},
				new String[] {
					"Как ты думаешь, {name} пойдет на преступление ради любви?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты поздравишь своего бывшего парня с днём влюбленных?",
					"Ты поздравишь свою бывшую девушку с днём влюбленных?",
				},
				new String[] {
					"Как ты считаешь, {name} поздравит своего бывшего парня с днём влюблённых?",
					"Как ты считаешь, {name} поздравит свою бывшую девушку с днём влюблённых?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты хорошо целуешься?",
				},
				new String[] {
					"Как ты думаешь, {name} хорошо целуется?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты помнишь свою первую любовь?",
				},
				new String[] {
					"Угадай, помнит ли {name} свою первую любовь?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"{name} сумел очаровать тебя?",
					"{name} сумела очаровать тебя?",
				},
				new String[] {
					"Как ты думаешь, {name} очарована тобой?",
					"Как ты думаешь, {name} очарован тобой?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"{name} - неплохая компания для похода в кино?",
				},
				new String[] {
					"По-твоему, {name} хотела бы пригласить тебя в кино?",
					"По-твоему, {name} хотел бы пригласить тебя в кино?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты целовалась когда-нибудь с незнакомцем?",
					"Ты целовался когда-нибудь с незнакомкой?",
				},
				new String[] {
					"Как ты думаешь, {name} целовалась когда-нибудь с незнакомцем?",
					"Как ты думаешь, {name} целовался когда-нибудь с незнакомкой?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты встречалась когда-нибудь сразу с двумя парнями?",
					"Ты встречался когда-нибудь сразу с двумя девушками?",
				},
				new String[] {
					"Угадай, {name} встречалась когда-нибудь сразу с двумя парнями?",
					"Угадай, {name} встречался когда-нибудь сразу с двумя девушками?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты стала бы встречаться с курящим парнем?",
					"Ты стал бы встречаться с курящей девушкой?",
				},
				new String[] {
					"По-твоему, {name} станет встречаться с курящим парнем?",
					"По-твоему, {name} станет встречаться с курящей девушкой?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты долго собираешься на свидание?",
				},
				new String[] {
					"Как думаешь, долго ли {name} собирается на свидание?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты когда-нибудь знакомилась в смс-чатах?",
					"Ты когда-нибудь знакомился в смс-чатах?",
				},
				new String[] {
					"Угадай, {name} когда-нибудь знакомилась в смс-чатах?",
					"Угадай, {name} когда-нибудь знакомился в смс-чатах?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты мечтаешь о создании семьи в ближайшем будущем?",
				},
				new String[] {
					"Как ты считаешь, мечтает ли {name} о создании семьи в ближайшем будущем?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты сможешь держать что-то в секрете от любимого человека?",
				},
				new String[] {
					"Как ты думаешь, сможет ли {name} держать секреты от любимого человека?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты положительно смотришь на свободные отношения?",
				},
				new String[] {
					"{name} положительно смотрит на свободные отношения?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты целуешься с закрытыми глазами?",
				},
				new String[] {
					"Угадай, {name} целуется с закрытыми глазами?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты готова дарить любимому дорогие подарки?",
					"Ты готов дарить любимой дорогие подарки?",
				},
				new String[] {
					"По-твоему, {name} готова дарить любимому дорогие подарки?",
					"По-твоему, {name} готов дарить любимой дорогие подарки?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Может ли {name} получить от тебя поцелуй на вашем первом свидании?",
				},
				new String[] {
					"Поцелует ли тебя {name} на вашем первом свидании?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты считаешь себя симпатичной девушкой?",
					"Ты считаешь себя симпатичным парнем?",
				},
				new String[] {
					"Как ты думаешь, {name} считает cебя симпатичной девушкой?",
					"Как ты думаешь, {name} считает cебя симпатичным парнем?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь пошло пошутить иногда?",
				},
				new String[] {
					"Угадай, любит ли {name} двусмысленно пошутить?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты правдиво отвечаешь на все вопросы?",
				},
				new String[] {
					"Как ты думаешь, правдиво ли {name} отвечает на вопросы?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты строишь планы на будущее?",
				},
				new String[] {
					"Как ты думаешь, {name} уже строит планы на будущее?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты часто видишь эротические сны?",
				},
				new String[] {
					"Угадай, часто ли {name} видит эротические сны?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты хранишь фотки бывших парней?",
					"Ты хранишь фотки бывших девушек?",
				},
				new String[] {
					"Как ты думаешь, {name} хранит фотки бывших парней?",
					"Как ты думаешь, {name} хранит фотки бывших девушек?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь простить измену?",
				},
				new String[] {
					"Может ли {name} простить измену?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты умеешь говорить комплименты?",
				},
				new String[] {
					"Умеет ли {name} говорить комплименты?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты часто влюбляешься?",
				},
				new String[] {
					"Часто ли {name} влюбляется?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты считаешь, что отношения можно купить за деньги?",
				},
				new String[] {
					"Считает ли {name}, что отношения можно купить за деньги?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Если {name} попросит тебя приготовить романтический ужин, ты согласишься?",
				},
				new String[] {
					"Согласится ли {name} приготовить для тебя романтический ужин?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты мечтаешь о свадьбе?",
				},
				new String[] {
					"Мечтает ли {name} о свадьбе?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты хочешь спонтанных и недолгих отношений?",
				},
				new String[] {
					"Угадай, хочет ли {name} спонтанных и недолгих отношений с тобой?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты веришь в вечную любовь?",
				},
				new String[] {
					"Верит ли {name} в вечную любовь?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты считаешь Памелу Андерсон сексуальной?",
				},
				new String[] {
					"Считает ли {name} Памелу Андерсон сексуальной?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь завтракать в постели?",
				},
				new String[] {
					"{name} любит завтракать в постели?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты надеешься на то, что у вас возникнет симпатия друг к другу?",
				},
				new String[] {
					"Надеется {name} на то, что у вас возникнет симпатия друг к другу?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты хочешь, чтобы любовь спасла мир?",
				},
				new String[] {
					"Хочет ли {name}, чтобы любовь спасла мир?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты уделяешь большое внимание интимной стороне жизни?",
				},
				new String[] {
					"Как думаешь, {name} уделяет большое внимание интимной стороне жизни?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Тебе нравится получать комплименты?",
				},
				new String[] {
					"На твой взгляд, {name} любит получать комплименты?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Если тебя разбудить ночью, сможешь назвать имя любимого?",
					"Если тебя разбудить ночью, сможешь назвать имя любимой?",
				},
				new String[] {
					"Как ты считаешь, если {name} проснётся ночью, то сможет назвать имя любимого?",
					"Как ты считаешь, если {name} проснётся ночью, то сможет назвать имя любимой?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты сможешь в интимной ситуации спутать имя любимого с другим именем?",
					"Ты сможешь в интимной ситуации спутать имя любимой с другим именем?",
				},
				new String[] {
					"Как думаешь, {name} в интимной ситуации путает имя любимого с другим именем?",
					"Как думаешь, {name} в интимной ситуации путает имя любимой с другим именем?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты сможешь за очень большие деньги отказаться от любви?",
				},
				new String[] {
					"Как думаешь, {name} за очень большие деньги откажется от любви?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь кого-нибудь?",
				},
				new String[] {
					"Как думаешь, {name} любит кого-нибудь?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты хочешь соблазнить партнёра по игре?",
				},
				new String[] {
					"Как думаешь, {name} хочет тебя соблазнить?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты сможешь пойти на всё ради своих близких?",
				},
				new String[] {
					"На твой взгляд, {name} сможет пойти на всё ради своих близких?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты променяешь просмотр любимого сериала на прогулку под луной?",
				},
				new String[] {
					"Как думаешь,  {name} променяет просмотр любимого сериала на прогулку под луной?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь признаться в любви мало знакомому человеку?",
				},
				new String[] {
					"Думаешь, {name} может признаться в любви мало знакомому человеку?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты сможешь прожить всю жизнь с одним человеком?",
				},
				new String[] {
					"Как думаешь, {name} сможет прожить всю жизнь с одним человеком?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты сможешь почувствовать измену?",
				},
				new String[] {
					"На твой взгляд, {name} почувствует измену?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты часто закатываешь истерики?",
				},
				new String[] {
					"Как считаешь, {name} часто закатывает истерики?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь повысить голос на любимого человека?",
				},
				new String[] {
					"Как думаешь, {name} может повысить голос на любимого человека?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты согласишься уехать в кругосветное путешествие с мало знакомым человеком за его счёт?",
				},
				new String[] {
					"Согласится ли {name} уехать в кругосветное путешествие с мало знакомым человеком за его счёт? ",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты сможешь уйти из ресторана не расплатившись?",
				},
				new String[] {
					"Сможет ли {name} уйти из ресторана не расплатившись?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь из-за мелочи разыграть публичный скандал?",
				},
				new String[] {
					"Может ли {name} из-за мелочи разыграть публичный скандал?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты даришь подарки своей половинке только по праздникам?",
				},
				new String[] {
					"{name} дарит подарки своей половинке только по праздникам?",
				},
			}),
			new OneVariant(new String[] {
				"Ты хочешь себе парня со спортивным телосложением?",
				"Угадай, {string} хочет себе парня со спортивным телосложением?",
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Должен ли быть твой партнёр сексуальным?",
				},
				new String[] {
					"Как думаешь, {name} считает, что её партнёр должен быть сексуальным?",
					"Как думаешь, {name} считает, что его партнёр должен быть сексуальным?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты хочешь себе заботливого партнёра?",
				},
				new String[] {
					"Угадай, {name} хочет себе заботливого партнёра?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Для тебя важно, чтобы решения в паре принимались сообща?",
				},
				new String[] {
					"Как думаешь, {name} хочет, чтобы решения в паре принимались сообща?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Тебе невыносимо однообразие в отношениях?",
				},
				new String[] {
					"{name} не выносит однообразие в отношениях?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты ревнива?",
					"Ты ревнив?",
				},
				new String[] {
					"{name} ревнива?",
					"{name} ревнив?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты часто ходишь на свидания?",
				},
				new String[] {
					"{name} часто ходит на свидания?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты готова ради любимого уйти на менее оплачиваемую работу?",
					"Ты готов ради любимой уйти на менее оплачиваемую работу?",
				},
				new String[] {
					"Как думаешь, {name} готова ради любимого уйти на менее оплачиваемую работу?",
					"Как думаешь, {name} готов ради любимой уйти на менее оплачиваемую работу?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь ради любимого отказаться от вредных привычек?",
					"Ты можешь ради любимой отказаться от вредных привычек?",
				},
				new String[] {
					"Предположи, {name} ради любимого может отказаться от вредных привычек?",
					"Предположи, {name} ради любимой может отказаться от вредных привычек?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты планируешь завести детей?",
				},
				new String[] {
					"Как ты думаешь, {name} планирует завести детей?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты любишь экспериментировать в постели?",
				},
				new String[] {
					"По-твоему, {name} любит экспериментировать в постели?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты часто разочаровываешься в противоположном поле?",
				},
				new String[] {
					"Угадай, {name} часто разочаровывается в противоположном поле? ",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты будешь баловать свою вторую половинку?",
				},
				new String[] {
					"Угадай, {name} будет баловать свою вторую половинку?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Тебе приятно сделать что-нибудь для любимого человека, даже если это мелочь?",
				},
				new String[] {
					"Угадай, {name} была бы рада сделать что-нибудь приятное для любимого человека, даже если это мелочь?",
					"Угадай, {name} был бы рад сделать что-нибудь приятное для любимого человека, даже если это мелочь?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты согласна, что примерно через 15 лет привычка – главный стимул совместной жизни?",
					"Ты согласен, что примерно через 15 лет привычка – главный стимул совместной жизни?",
				},
				new String[] {
					"По-твоему, {name} считает, что примерно через 15 лет привычка – главный стимул совместной жизни?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Легко ли ты проявляешь свои чувства?",
				},
				new String[] {
					"Угадай, легко ли {name} проявляет свои чувства?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Тебе трудно определить что такое любовь?",
				},
				new String[] {
					"Как ты думаешь, {name} легко скажет что для неё любовь?",
					"Как ты думаешь, {name} легко скажет что для него любовь?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты сможешь простить курортный роман своему партнёру?",
				},
				new String[] {
					"По-твоему, {name} сможет простить курортный роман своему партнёру?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Важен ли для тебя секс в отношениях?",
				},
				new String[] {
					"По-твоему, {name} считает, что секс важен в отношениях?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Как ты считаешь, на расстоянии любовь умирает?",
				},
				new String[] {
					"Угадай, {name} считает, что на расстоянии любовь умирает?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты готова смириться с беспорядком в квартире?",
					"Ты готов смириться с беспорядком в квартире?",
				},
				new String[] {
					"Угадай, {name} готова смириться с беспорядком в квартире?",
					"Угадай, {name} готов смириться с беспорядком в квартире?",
				},
			}),
			new OneVariant(new String[] {
				"Ты готова завести ребёнка?",
				"Ты готов завести ребёнка?",
			}),
			new OneVariant(new String[] {
				"Ты обсуждаешь семейные проблемы со своими друзьями?",
			}),
			new OneVariant(new String[] {
				"Ты даёшь поводы для ревности?",
			}),
			new OneVariant(new String[] {
				"Ради любви сможешь переехать в другой город?",
			}),
			new OneVariant(new String[] {
				"Ты посещаешь сайты эротического содержания?",
				"Считаешь, она часто посещает сайты эротического содержания?",
			}),
			new OneVariant(new String[] {
				"Ты бы отдала своего кота, если бы у твоего парня была аллергия на животных?",
				"Отдала бы она своего кота, если бы у её парня была аллергия на его шерсть?",
			}),
			new OneVariant(new String[] {
				"Ты готова смириться с тем, что твой парень разбрасывает носки по квартире?",
				"Смирилась бы она с тем, что её парень разбрасывает носки по квартире?",
			}),
			new OneVariant(new String[] {
				"Ты часто даёшь повод для ревности?",
				"Как ты думаешь, часто ли она даёт повод для ревности?",
			}),
			new OneVariant(new String[] {
				"Ты позволяешь себе кокетничать с другими мужчинами, будучи в паре?",
				"Как ты считаешь, она позволяет себе в отношениях кокетничать с другими мужчинами?",
			}),
			new OneVariant(new String[] {
				"Ты можешь накричать на своего парня?",
				"Думаешь, она может накричать в присутствии посторонних?",
			}),
			new OneVariant(new String[] {
				"Ты отказывалась хоть раз от предложения руки и сердца?",
				"Как ты думаешь, отказывалась ли она хоть раз от предложения руки и сердца?",
			}),
			new OneVariant(new String[] {
				"Ты нуждаешься в крепком мужском плече?",
				"Как ты думаешь, нуждается ли она в крепком мужском плече?",
			}),
			new OneVariant(new String[] {
				"Ты хочешь быть лидером в отношениях?",
				"Как ты считаешь, лидер ли она в отношениях?",
			}),
			new OneVariant(new String[] {
				"Думала ли ты хоть раз о том, что больше никогда не сможешь любить?",
				"Как ты считаешь, думала ли она когда-нибудь о том, что больше никогда не сможет любить?",
			}),
			new OneVariant(new String[] {
				"Ты можешь сама предложить парню свидание?",
				"Угадай, {string} может сама предложить парню свидание?",
			}),
			new OneVariant(new String[] {
				"Ты ладишь со своей мамой?",
				"Как ты думаешь, она ладит со своей мамой?",
			}),
			new OneVariant(new String[] {
				"Ты можешь собраться за пять минут на свидание с парнем?",
				"Как ты думаешь, может ли она собраться за пять минут на свидание?",
			}),
			new OneVariant(new String[] {
				"Ты веришь в принца на белом коне?",
				"Угадай, {string} верит в принца на белом коне?",
			}),
			new OneVariant(new String[] {
				"Ты хочешь, чтобы любимый приносил завтрак в постель?",
				"Угадай, {string} хочет завтрак в постель от любимого?",
			}),
			new OneVariant(new String[] {
				"Как ты думаешь, для него важна семья?",
				"Для тебя важна семья?",
			}),
			new OneVariant(new String[] {
				"Как ты думаешь, из-за любви он готов жениться на девушке с детьми?",
				"Из-за любви ты готов жениться на девушке с детьми?",
			}),
			new OneVariant(new String[] {
				"Угадай, {string} плакал хоть раз после разрыва отношений?",
				"Ты плакал хоть раз после разрыва отношений?",
			}),
			new OneVariant(new String[] {
				"Как ты думаешь, у него было много девушек?",
				"У тебя было много девушек?",
			}),
			new OneVariant(new String[] {
				"Как ты думаешь, {string} считает, что ложь во имя добра - это правильное решение?",
				"Ложь, но во имя добра - это правильное решение?",
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты училась целоваться на помидорах?",
					"Ты учился целоваться на помидорах?",
				},
				new String[] {
					"Как ты думаешь, училась целоваться на помидорах?",
					"Как ты думаешь, учился целоваться на помидорах?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Тебя когда-нибудь предавали друзья?",
				},
				new String[] {
					"Как думаешь, {name} когда-нибудь была предана другом?",
					"Как думаешь, {name} когда-нибудь был предан другом?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты легко находишь общий язык с людьми?",
				},
				new String[] {
					"Думаешь, {name} легко находит общий язык с людьми?",
				},
			}),
			new OneVariant(new String[] {
				"Ты бы хотела стать любимой девушкой супергероя?",
				"Думаешь, {string} хотела бы стать любимой девушкой супергероя?",
			}),
			new OneVariant(new String[] {
				"Ты хотела бы, чтобы {string} тебя спас?",
				"Думаешь, {string} хотела бы, чтобы ты её спас?",
			}),
			new OneVariant(new String[] {
				"Для тебя приемлем секс на первом свидании?",
				"Как считаешь, {string} готова заняться сексом на первом свидании?",
			}),
			new OneVariant(new String[] {
				"Как ты думаешь, {string} - однолюб?",
				"Ты однолюб?",
			}),
			new OneVariant(new String[] {
				"Ты можешь любить двух мужчин одновременно?",
				"Думаешь, {string} может любить двух мужчин одновременно?",
			}),
			new OneVariant(new String[] {
				"Думаешь, {string} всегда сдерживает обещания?",
				"Ты всегда держишь обещания?",
			}),
			new OneVariant(new String[] {
				"Ты часто опаздываешь на свидания?",
				"Думаешь, {string} часто опаздывает на свидания?",
			}),
			new OneVariant(new String[] {
				"Ты мечтаешь об истории любви, как в фильмах?",
				"Думаешь, {string} мечтает об истории любви, как в фильмах?",
			}),
			new OneVariant(new String[] {
				"Думаешь, {string} смог бы встречаться с девушкой, которая умнее его?",
				"Ты бы смог встречаться с девушкой, которая умнее тебя?",
			}),
			new OneVariant(new String[] {
				"Ты согласна, что человеку для счастья нужно 8 объятий в день?",
				"Ты согласен, что человеку для счастья нужно 8 объятий в день?",
			}),
			new OneVariant(new String[] {
				"Твои родители являются для тебя примером для подражания?",
			}),
			new OneVariant(new String[] {
				"Ты согласна, что мужчина должен делать первый шаг в отношениях?",
				"Ты согласен, что мужчина должен делать первый шаг в отношениях?",
			}),
			new OneVariant(new String[] {
				"Ты веришь в любовь после секса?",
			}),
			new OneVariant(new String[] {
				"Ты веришь в дружбу между мужчиной и женщиной?",
			}),
			new OneVariant(new String[] {
				"Ты больше веришь поступкам, чем словам?",
			}),
			new OneVariant(new String[] {
				"Могут ли обстоятельства разлучить тебя с любимым человеком?",
			}),
			new OneVariant(new String[] {
				"Ты расстанешься с любимым, если друзья и родные будут против?",
				"Ты расстанешься с любимой, если друзья и родные будут против?",
			}),
			new OneVariant(new String[] {
				"Ты часто влюбляешься безответно?",
			}),
			new OneVariant(new String[] {
				"С тобой сложно ужиться?",
			}),
			new OneVariant(new String[] {
				"Тебе важно мнение твоей половинки абсолютно по всем вопросам?",
			}),
			new OneVariant(new String[] {
				"Ты считаешь, что в отношениях нужно говорить друг другу всё без утайки?",
			}),
			new OneVariant(new String[] {
				"Твоя половинка для тебя важнее твоих друзей?",
			}),
			new OneVariant(new String[] {
				"Ты веришь, что настоящая любовь бывает в жизни только одна?",
			}),
			new OneVariant(new String[] {
				"Ты согласна, что секс после ссоры самый лучший?",
				"Ты согласен, что секс после ссоры самый лучший?",
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты можешь предать друга?",
				},
				new String[] {
					"Как думаешь, {name} может предать друга?",
				},
			}),
			new TwoVariants(new String[2][] {
				new String[] {
					"Ты звонишь своим бывшим, когда выпьешь?",
				},
				new String[] {
					"Думаешь, {name} звонит бывшим, когда выпьет?",
				},
			}),
			new OneVariant(new String[] {
				"Думаешь, {string} боится женских слёз?",
				"Ты боишься женских слёз?",
			}),
			new OneVariant(new String[] {
				"Ты могла бы выйти замуж по рассчёту?",
				"Думаешь, {string} могла бы выйти замуж по рассчёту?",
			}),
			new OneVariant(new String[] {
				"Думаешь, он женился бы на девушке только потому, что она забеременела?",
				"Ты женился бы на девушке только потому, что она забеременела?",
			}),
			new OneVariant(new String[] {
				"Ты согласна, что от любви до ненависти один шаг?",
				"Ты согласен, что от любви до ненависти один шаг?",
			}),
			new OneVariant(new String[] {
				"Ты согласна с утверждением, что любовь живёт 3 года?",
				"Ты согласен с утверждением, что любовь живёт 3 года?",
			}),
			new OneVariant(new String[] {
				"Ты согласна, что любовь зла?",
				"Ты согласен, что любовь зла?",
			}),
			new OneVariant(new String[] {
				"Ты согласна с фразой «стерпится-слюбится»?",
				"Ты согласен с фразой «стерпится-слюбится»?",
			}),
			new OneVariant(new String[] {
				"Тебе когда-нибудь разбивали сердце?",
			}),
		};
	}
}

