function isNumber(evt) {
	evt = (evt) ? evt : window.event;
	var charCode = (evt.which) ? evt.which : evt.keyCode;
	if (charCode > 31 && (charCode < 48 || charCode > 57)) {
		return false;
	}
	return true;
}
function lengthCheck(element, length) {
	if (element.value.length > length) {
		element.focus();
		return false
	}
	else
		return true;
}
function showError(element, length) {
	if (element.value.length <= length) {
		element.style.borderColor = '#1F497D';
	}
}
function checkPhoneNum() {
	return document.getElementById("Phone").value.length == 12;
}
function validateName() {
	var regName = /^[a-zA-Z]+( [a-zA-Z]+)+$/;
	var name = document.getElementById('ContentPlaceHolder1_name').value;
	var element = document.getElementById('ContentPlaceHolder1_name');
	if (!regName.test(name)) {
		element.style.borderStyle = '#1F497D';
		element.focus();
		return false;
	} else {
		return true;
	}
}
function validate() {
	return validateRBs() && validateName();
}