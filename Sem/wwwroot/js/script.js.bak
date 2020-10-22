// Открытие страницы (статья)
function openArticle() {
	document.location.href = "news"
}

// Открытие страницы (дискуссия)
function openDebate() {
	document.location.href = "debate";
}


// Изменение сторон дебатов
function chatChangeAgainst(index) {
	let against_btn = $("#against-btn")
	let send_btn = $("#send-btn")
	if (index === 1){
		against_btn.removeClass("btn-secondary btn-danger");
		against_btn.addClass("btn-success");
		against_btn.html("За");

		send_btn.removeClass("btn-secondary btn-danger");
		send_btn.addClass("btn-success");
	}
	else if (index === 0){
		against_btn.removeClass("btn-secondary btn-success");
		against_btn.addClass("btn-danger");
		against_btn.html("Против");

		send_btn.removeClass("btn-secondary btn-success");
		send_btn.addClass("btn-danger");
	}
}


// Отправка сообщений
function chatSendMessage(){
	let against = $("#against-btn").attr("class").split(" ")[1];
	if (against === "btn-secondary"){
		alert("Выберите сторону");
		return;
	}
	let chatInput = $("#chatInput")
	let messege = messageFilter(chatInput.val());
	if (messege === "") return;
	chatInput.val("");


	// Тут нужно узнать последнее сообщение было отправлено нами или нет ?!?!
	// Как это сделать я пока не знаю, может как то через Базу данных

	// Суть в том что нужно последующее сообщение сунуть в "message-box" последнего сообщения если это твоё сообщение


	//let lastMessage = $(".chat-body").children().last().children(".message-box");
	// console.log(lastMessage);




	if (against === "btn-success"){
		let model = "<div class=\"message-green\">" +
						"<img class=\"messege-img\" src=\"https://img.icons8.com/color/36/000000/administrator-male.png\" alt=\"\">"+
						"<div class=\"message-place\">" +
							"<div class=\"message-box\">" +
								"<div class=\"message\">" + messege + "</div>" +
							"</div>" +
						"</div>" +
					"</div>";
		let chat_green = $("#chat-green")
		chat_green.append(model);
		chat_green.scrollTop(chat_green.prop('scrollHeight'));
	}
	else if (against === "btn-danger"){
		let model = "<div class=\"message-red\">" +
						"<img class=\"messege-img\" src=\"https://img.icons8.com/color/36/000000/administrator-male.png\" alt=\"\">"+
						"<div class=\"message-place\">" +
							"<div class=\"message-box\">" +
								"<div class=\"message\">" + messege + "</div>" +
							"</div>" +
						"</div>" +
					"</div>";
		let chat_red = $("#chat-red")
		chat_red.append(model);
		chat_red.scrollTop(chat_red.prop('scrollHeight'));
	}

}

function messageFilter(str) {
	return str;
}


// Создание дискуссии
function createDebate() {
	let form = document.Construntor;

	let title = form.con_title.value;
	let describe = form.con_describe.value;
	let key_words = form.con_keywords.value;

	log(title);
	log(describe);
	log(key_words);
}



// Выбор ключевых слов
function selectKeyWord(key) {
	let con_keywords_input = $(".con-keywords-input")
	if (con_keywords_input.children().length >= 3){
		
		alert("Максимальное количество ключевых слов равно 3");

		return;
	}

	let word = key.innerHTML;
	let model = "<div onclick=\"deleteKeyWord(this)\" class=\"key-word-box\">" +
					"<div class=\"key-word-text\">" +
						word +
					"</div>" +
					"<div class=\"key-word-delete-box\">" +
						"<img class=\"key-word-delete\" src=\"icons/delete.svg\" alt=\"\">" +
					"</div>" +
				"</div>";

	con_keywords_input.append(model);
}

function deleteKeyWord(key) {
	key.remove();
}



function loadImgForm() {
	$('#exampleModal').on('shown.bs.modal', function () {
		$('#exampleModal').trigger('focus')
	})
}


// Custom methods
function log(srt) {
	console.log(srt);
}