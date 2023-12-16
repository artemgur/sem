// // Открытие страницы (статья)
// function openArticle() {
// 	document.location.href = "news"
// }

// Открытие страницы (дискуссия)
function openDebate() {
	document.location.href = "/debate";
}

function openDebateConstructor() {
	document.location.href = "/constructor";
}





// Вход / Регистрация / Выход
function login() {
	let form = document.loginForm;

	//var mail = form.email.value;
	let username = form.username.value;
	let password = form.password.value;
	let remember = form.remember.checked;

	let searchParams = new URLSearchParams(window.location.search)

	// if (!passwordValidate(password)) {
	// 	alert("Пароль не соответствует требованиям");
	// 	return;
	// }
	// else {
		//alert("Все ок")

	$.ajax({
			type: 'POST',
			url: '/authenticate',
			headers: {
				'username': username,
				'password': password,
				'remember': remember
				//'desired_path': searchParams.has('desired_path') ? searchParams.get('desired_path') : ""
			},
			success: function (res, status, xhr) {
				//alert(123);
				let result = xhr.getResponseHeader("auth_result")
				if (result === "success")
					document.location.href = searchParams.has('desired_path') ? searchParams.get('desired_path') : "account-main"
				else
					alert("Неверный логин или пароль")
			}
		})
}
function register() {
	let form = document.registerForm;

	//var mail = form.email.value;
	let username = form.username.value;
	let password = form.password.value;
	//var password = form.password.value;
	let secondPassword = form.password_confirmation.value;
	let remember = form.remember.checked;
	
	let searchParams = new URLSearchParams(window.location)
	
	if (!passwordValidate(password) || password !== secondPassword) {
		alert("Пароль не соответствует требованиям");
		return;
	}
	else {
		//console.log(searchParams.get('desired_path'))
		//alert("Все ок")
		$.ajax({
			type: 'POST',
			url: '/authenticate',
			headers: {
				'register': "",
				'username': username,
				'password': password,
				'remember': remember
				//'desired_path': searchParams.has('desired_path') ? searchParams.get('desired_path') : ""
			},
			success: function(res, status, xhr) {
				let result = xhr.getResponseHeader("auth_result")
				if (result === "success")
					document.location.href = searchParams.has('desired_path') ? searchParams.get('desired_path') : "account-main"
				else 
					alert("Пользователь с таким логином уже зарегистрирован")
			}
		})
	}
}
function logout() {

	//$.ajax({
	//	type: 'POST',
	//	url: '/authenticate',
	//	headers: {
	//		'register': "logout"
	//	}
	//	//success: function (res, status, xhr) {
	//	//	let result = xhr.getResponseHeader("auth_result")
	//	//	if (result === "success")
	//	//		document.location.href = searchParams.has('desired_path') ? searchParams.get('desired_path') : "account-main"
	//	//	else
	//	//		alert("Пользователь с таким логином уже зарегистрирован")
	//	//}
	//})

	alert("Вы вышли из системы");
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
	let message = messageFilter(chatInput.val());
	if (message === "") return;
	chatInput.val("");


	// Тут нужно узнать последнее сообщение было отправлено нами или нет ?!?!
	// Как это сделать я пока не знаю, может как то через Базу данных

	// Суть в том что нужно последующее сообщение сунуть в "message-box" последнего сообщения если это твоё сообщение


	//let lastMessage = $(".chat-body").children().last().children(".message-box");
	// console.log(lastMessage);

	let imagePath = $("#user-image-path").val();

	let opinion;
	if (against === "btn-success"){
		let model = "<div class=\"message-green\">" +
						"<img class=\"message-img\" src=\"" + imagePath + "\" alt=\"\">"+
						"<div class=\"message-place\">" +
							"<div class=\"message-box\">" +
								"<div class=\"message\">" + message + "</div>" +
							"</div>" +
						"</div>" +
					"</div>";
		let chat_green = $("#chat-green")
		chat_green.append(model);
		chat_green.scrollTop(chat_green.prop('scrollHeight'));
		
		opinion = true
	}
	else if (against === "btn-danger"){
		let model = "<div class=\"message-red\">" +
						"<img class=\"message-img\" src=\"" + imagePath + "\" alt=\"\">"+
						"<div class=\"message-place\">" +
							"<div class=\"message-box\">" +
								"<div class=\"message\">" + message + "</div>" +
							"</div>" +
						"</div>" +
					"</div>";
		let chat_red = $("#chat-red")
		chat_red.append(model);
		chat_red.scrollTop(chat_red.prop('scrollHeight'));
		
		opinion = false
	}
	let path = document.location
	let debate_id = /\d+#?$/g.exec(path)[0]
	if (debate_id.charAt(debate_id.length - 1) === '#')
		debate_id = debate_id.slice(0, -1)
	$.ajax({
		type: 'POST',
		url: '/save_comment',
		headers: {
			'text': encodeURIComponent(message),
			'opinion': opinion,
			'debate_id': debate_id,
			//'tags': stringified
		},
		//data: stringified,
		// success: function(res, status, xhr) {
		// 	let id = xhr.getResponseHeader("id")
		// 	let result = xhr.getResponseHeader("status")
		// 	if (result === "success")
		// 		document.location.href = "/debate/"+id
		// }
	})


}

function messageFilter(str) {
	return str;
}


// Создание дискуссии
function createDebate() {
	let form = document.construntorForm;

	let title = form.construntorForm_title.value;
	let describe = form.construntorForm_describe.value;

	//Тут приходит масив ключевых слов. На данный момент максимальное количество = 3 |-> selectKeyWord() -> maxKeywords
	let key_words = document.getElementById("con-keywords-read").innerText.split("\n");
	if (key_words[0] === "")
	{
		alert("Выберите ключевые слова")
		return 
	}

	//Вывод
	//log(title);
	//log(describe);
	//log(key_words);
	let stringified = JSON.stringify(key_words)
	$.ajax({
		type: 'POST',
		url: '/create_debate',
		headers: {
			'title': encodeURIComponent(title),
			'text': encodeURIComponent(describe)
			//'tags': stringified
		},
		data: stringified,
		success: function(res, status, xhr) {
			let id = xhr.getResponseHeader("id")
			let result = xhr.getResponseHeader("status")
			if (result === "success")
				document.location.href = "/debate/"+id
		}
	})


	//alert("dfassdf")
}



// Выбор ключевых слов
function selectKeyWord(key) {
	let con_keywords_input = $(".con-keywords-input")
	let currentKey = key.innerHTML;

	//Тут можно задать максимальное количество для выбора ключевых слова
	let maxKeywords = 3;
	if (con_keywords_input.children().length >= maxKeywords){
		
		alert("Максимальное количество ключевых слов равно " + maxKeywords);

		return;
	}

	//Будем проверять, входит ли уже это ключевое слово, если оно уже присутствует -> return
	let key_words = document.getElementById("con-keywords-read").innerText.split("\n");
	if (key_words.indexOf(currentKey) != -1) {

		alert(currentKey + " уже выбрано");

		return;
    } 



	let model = "<div onclick=\"deleteKeyWord(this)\" class=\"key-word-box\">" +
					"<div class=\"key-word-text\">" +
						currentKey +
					"</div>" +
					"<div class=\"key-word-delete-box\">" +
						"<img class=\"key-word-delete\" src=\"icons/delete.svg\" alt=\"\">" +
					"</div>" +
				"</div>";

	con_keywords_input.append(model);
}

//Удаление ключевого клова
function deleteKeyWord(key) {
	key.remove();
}



function loadImgForm() {
	$('#exampleModal').on('shown.bs.modal', function () {
		$('#exampleModal').trigger('focus')
	})
}




//Поиск по сайту
function searchInfo() {
	let form = document.searchForm;

	let searchValue = form.search.value;
	let searchFilter = form.searchFilterBox.innerHTML;

	// if (searchFilter == "Фильтры") {
	// 	searchFilter = "";
	// }

	//Тут у нас имеется 2 параметра
	//Само значени: searchValue
	//И фильтр: searchFilter, если фильтр не выбран, то searchFilter пустая строка

	let path = document.location.href;
	var pathBeginning = "index"
	if (path.includes("debate") || path.includes("constructor"))
		pathBeginning = "debates"
	if (path.includes("people"))
		pathBeginning = "people"
	let l = pathBeginning + "?search_text="+searchValue
	if (searchFilter != "Фильтры") {
		l += "&search_tag="+searchFilter
	}
	document.location = l

	//alert(searchValue + " " + searchFilter);
}

function changeSearchFilter(filter) {
	let filterValue = filter.innerHTML;

	let form = document.searchForm;
	if (filterValue == "Не выбрано") {
		form.searchFilterBox.innerHTML = "Фильтры";
	}
	else {
		form.searchFilterBox.innerHTML = filterValue;
    }
}




//Добавление или удаление из избранного
function addToFavorites() {
	let path = document.location;
	let id = /\d+$/g.exec(path); //Тут применяется регулярное выражение
	//alert(id); //В дальнейшем удалить

	//TODO: Добавить статью в избранные с указанным id

	$.ajax({
		type: 'POST',
		url: '/favorite',
		headers: {
			'action': 'add',
			'article_id': id
		},
		success: function(res, status, xhr) {
			let result = xhr.getResponseHeader("status")
			if (result === "success")
			{
				$("#article-function-addToFavorites").css("display", "none");
				$("#article-function-removeFromFavorites").css("display", "flex");
			}
			else
				alert("Чтобы добавить статью в избранное, нужно зарегистрироваться")
		}
	})


	//Изменяем кнопку на противоположные как только выполнилось данная функция
	// $("#article-function-addToFavorites").css("display", "none");
	// $("#article-function-removeFromFavorites").css("display", "flex");
}

function removeFromFavorites() {
	let path = document.location;
	let id = /\d+$/g.exec(path); //Тут применяется регулярное выражение
	//alert(id); //В дальнейшем удалить

	//TODO: Удалить статью из избранного с указанным id

	$.ajax({
		type: 'POST',
		url: '/favorite',
		headers: {
			'action': 'delete',
			'article_id': id
		},
		success: function(res, status, xhr) {
			let result = xhr.getResponseHeader("status")
			if (result === "success")
			{
				$("#article-function-addToFavorites").css("display", "flex");
				$("#article-function-removeFromFavorites").css("display", "none");
			}
			else
				alert("Чтобы добавить статью в избранное, нужно зарегистрироваться")
		}
	})


	//Изменяем кнопку на противоположные как только выполнилось данная функция
	// $("#article-function-addToFavorites").css("display", "flex");
	// $("#article-function-removeFromFavorites").css("display", "none");
}

function removeFromFavoritesNewsAccount(element, id) {
	event.stopPropagation()
	//TODO: Удалить статью из избранного с указанным id

	$.ajax({
		type: 'POST',
		url: '/favorite',
		headers: {
			'action': 'delete',
			'article_id': id
		},
		success: function(res, status, xhr) {
			let result = xhr.getResponseHeader("status")
			if (result === "success")
			{
				element.parentNode.remove();
				//TODO hide/remove card somehow
				//$("#article-function-addToFavorites").css("display", "flex");
				//$("#article-function-removeFromFavorites").css("display", "none");
			}
			else
				alert("Чтобы добавить статью в избранное, нужно зарегистрироваться")
		}
	})
}



// Валидация пароля
function passwordValidate(str) {
	const beginWithoutDigit = /^\D/; // Начинается не с цифры
	const withoutSpecialChars = /^[^-()'/]*$/; // Не собержит специальные символы
	const containsLetters = /^.*[a-zA-Z]+.*$/; // Содержит буквы
	const minimum8Chars = /.{8,}/; // Минимум 8 символов
	const withoutSpaces = /\S/; // Не содержит пробелы

	let a = beginWithoutDigit.test(str);
	let b = withoutSpecialChars.test(str);
	let c = containsLetters.test(str);
	let d = minimum8Chars.test(str);
	let e = withoutSpaces.test(str);


	log(a + " " + b + " " + c + " " + d + " " + e);

	if (a && b && c && d && e) {
		return true;
	} else {
		return false;
	}
}


function changeAccountImage() {
	var input = document.getElementById("image_input")
	//var input1 = $("#image_input");
	var fd = new FormData();
	var file = input.files[0];
	
	fd.append('image', file, file.name);

	var xhr = new XMLHttpRequest();

	// Open the connection
	xhr.open('POST', '/save_image', true);
	//xhr.setRequestHeader("filename", file.name)

	// Set up a handler for when the task for the request is complete
	xhr.onload = function () {
		if (xhr.status === 200) {
			location.reload();//To update photo on page
			//alert('Upload copmlete!');
		}/* else {
			alert('Upload error. Try again.');
		}*/
	};

	// Send the data.
	xhr.send(fd);
	//location.reload()
	 // $.ajax({
	 // 	type: 'POST',
	 // 	url: '/save_image',
	 // 	data: fd, //Image itself should be here
	 // 	dataType: 'image/jpg', //+extension
	 // 	success: function(res, status, xhr) {
		// 	  alert(1);
	 // 	}
	 // 	//headers: {
	 // 	// 'filename': img
	 // 	//}
	 // })
	 // $(".account-img").attr("src", img);
}


//Скролинг
$(window).scroll(function () {
	var target = $(this).scrollTop();
	if (target > 400) {
		$(".scroller").css("display", "block");
	}
	else {
		$(".scroller").css("display", "none");
    }
})

function toScrollTop() {
	$("html").animate({
		scrollTop: 0
	}, 1000);
}





// Custom methods
function log(srt) {
	console.log(srt);
}

//Тут можно написать фильтрацию сообщений
function messageFilter(str) {
	return str;
}