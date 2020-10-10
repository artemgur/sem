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

	var messege = $("#chatInput").val();
	if (messege == "") return;
	$("#chatInput").val("");


	// Тут нужно узнать последнее сообщение было отправлено нами или нет ?!?!
	// Как это сделать я пока не знаю, может как то через Базу данных

	// Суть в том что нужно последующее сообщение сунуть в "message-box" последнего сообщения если это твоё сообщение


	var lastMessage = $(".chat-body").children().last().children(".message-box");
	console.log(lastMessage);

	// $(".chat-body").



	if (against == "btn-success"){
		var model = "<div class=\"message-green\">" +
						"<img class=\"messege-img\" src=\"https://img.icons8.com/color/36/000000/administrator-male.png\" alt=\"\">"+
						"<div class=\"message-box\">" +
							"<div class=\"message\">" + messege + "</div>" +
						"</div>" +
					"</div>"
	}
	else if (against == "btn-danger"){
		var model = "<div class=\"message-red\">" +
						"<img class=\"messege-img\" src=\"https://img.icons8.com/color/36/000000/administrator-male.png\" alt=\"\">"+
						"<div class=\"message-box\">" +
							"<div class=\"message\">" + messege + "</div>" +
						"</div>" +
					"</div>"
	}

	$(".chat-body").append(model);
}

function addMessege()
{

	// var b = "<div class=\"media media-chat media-chat-reverse\"> <div class=\"media-body\"> <p>" + a + "</p> <p class=\"meta\"><time datetime=\"2018\">00:06</time></p> </div> </div>"
	// $("#messege").prepend(b);
	// document.getElementById("inputmessege").value = "";
}


$(".chat-form").on("submit", function(){
	console.log("123");
	chatSendMessage();
})