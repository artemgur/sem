function openNews() {
	document.location.href = "news.html";
}

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

function chatSendMessage(){
	var against = $("#against-btn").attr("class").split(" ")[1];
	if (against == "btn-secondary"){
		alert("Выберите сторону");
		return;
	}

	var messege = messageFilter($("#chatInput").val());
	if (messege == "") return;
	$("#chatInput").val("");


	// Тут нужно узнать последнее сообщение было отправлено нами или нет ?!?!
	// Как это сделать я пока не знаю, может как то через Базу данных

	// Суть в том что нужно последующее сообщение сунуть в "message-box" последнего сообщения если это твоё сообщение


	var lastMessage = $(".chat-body").children().last().children(".message-box");
	// console.log(lastMessage);




	if (against == "btn-success"){
		var model = "<div class=\"message-green\">" +
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
		var model = "<div class=\"message-red\">" +
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

function createDebate() {
	let form = document.Construntor;

	let title = form.con_title.value;
	let describe = form.con_describe.value;
	let img = form.con_img.value;
	let key_words = form.con_keywords.value;

	log(title);
	log(describe);
	log(img);
	log(key_words);
	console.log();


}


function log(srt) {
	console.log(srt);
}