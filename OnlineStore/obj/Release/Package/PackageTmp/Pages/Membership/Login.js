function lengthCheck(element) {
	if (element.value.length > 50) {
		element.focus();
		return false
	}
	else {
		return true;
	}
}
function showError(element) {
	if (element.value.length <= 50) {
		element.style.borderColor = '#1F497D';
	}
}
function validateEmail() {
	var mailformat = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
	var email = document.getElementById("Email");
	if (email.value.match(mailformat)) {
		email.style.borderColor = '#1F497D';
		email.focus();
		return true;
	}
	else {
		email.style.borderColor = 'red';
		email.focus();
		return false;
	}
}
function validate() {
	return validateEmail();
}