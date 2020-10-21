// Открытие страницы (статья)
function openArticle() {
	document.location.href = "@Url.Page(\"./news\")";//TODO fix
}

// Открытие страницы (дискуссия)
function openDebate() {
	document.location.href = "@Url.Page(\"./debate\")";//TODO fix
}


// Изменение сторон дебатов
function chatChangeAgainst(index) {
	if (index == 1){
		$("#against-btn").removeClass("btn-secondary btn-danger");
		$("#against-btn").addClass("btn-success");
		$("#against-btn").html("За");

		$("#send-btn").removeClass("btn-secondary btn-danger");
		$("#send-btn").addClass("btn-success");
	}
	else if (index == 0){
		$("#against-btn").removeClass("btn-secondary btn-success");
		$("#against-btn").addClass("btn-danger");
		$("#against-btn").html("Против");

		$("#send-btn").removeClass("btn-secondary btn-success");
		$("#send-btn").addClass("btn-danger");
	}
}


// Отправка сообщений
function chatSendMessage(){
	let against = $("#against-btn").attr("class").split(" ")[1];
	if (against == "btn-secondary"){
		alert("Выберите сторону");
		return;
	}

	let messege = messageFilter($("#chatInput").val());
	if (messege == "") return;
	$("#chatInput").val("");


	// Тут нужно узнать последнее сообщение было отправлено нами или нет ?!?!
	// Как это сделать я пока не знаю, может как то через Базу данных

	// Суть в том что нужно последующее сообщение сунуть в "message-box" последнего сообщения если это твоё сообщение


	let lastMessage = $(".chat-body").children().last().children(".message-box");
	// console.log(lastMessage);




	if (against == "btn-success"){
		let model = "<div class=\"message-green\">" +
						"<img class=\"messege-img\" src=\"https://img.icons8.com/color/36/000000/administrator-male.png\" alt=\"\">"+
						"<div class=\"message-place\">" +
							"<div class=\"message-box\">" +
								"<div class=\"message\">" + messege + "</div>" +
							"</div>" +
						"</div>" +
					"</div>";
		$("#chat-green").append(model);
		$("#chat-green").scrollTop($("#chat-green").prop('scrollHeight'));
	}
	else if (against == "btn-danger"){
		let model = "<div class=\"message-red\">" +
						"<img class=\"messege-img\" src=\"https://img.icons8.com/color/36/000000/administrator-male.png\" alt=\"\">"+
						"<div class=\"message-place\">" +
							"<div class=\"message-box\">" +
								"<div class=\"message\">" + messege + "</div>" +
							"</div>" +
						"</div>" +
					"</div>";
		$("#chat-red").append(model);
		$("#chat-red").scrollTop($("#chat-red").prop('scrollHeight'));
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
	if ($(".con-keywords-input").children().length >= 3){
		
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

	$(".con-keywords-input").append(model);
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