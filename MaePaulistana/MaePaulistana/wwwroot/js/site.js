$(document).ready(function () {
	toastr.options = {
		"closeButton": false,
		"debug": false,
		"newestOnTop": false,
		"progressBar": true,
		"positionClass": "toast-top-right",
		"preventDuplicates": true,
		"onclick": null,
		"showDuration": "300",
		"hideDuration": "1000",
		"timeOut": "5000",
		"extendedTimeOut": "1000",
		"showEasing": "swing",
		"hideEasing": "linear",
		"showMethod": "fadeIn",
		"hideMethod": "fadeOut"
	};
})

var patientData = {};
var telephones = [];

function addNewTelephone()
{
	// Captura os valores dos campos
	var telephoneValue = document.querySelector("#add-phone-button").closest("tr").querySelector(".ipt-telephone").value;
	var typeValue = document.querySelector("#selectTypeTel").value;
	var obsValue = document.querySelector("#add-phone-button").closest("tr").querySelector(".ipt-obs").value;

	if (telephoneValue === "" || telephoneValue === null || typeValue === "" || typeValue === null)
		return;

	// Criar um objeto JSON com os valores
	var dataToSave = {
		NumeroTelefone: telephoneValue,
		TipoTelefoneID: typeValue,
		ObsTelefone: obsValue
	};

	var copiedDataToSave = { ...dataToSave };

	telephones.push(copiedDataToSave);

	telephonesToAdd = {
		//PacienteID: document.getElementById("patientID").value,
		NumeroTelefone: copiedDataToSave.NumeroTelefone,
		TipoTelefoneID: copiedDataToSave.TipoTelefoneID,
		ObsTelefone: copiedDataToSave.ObsTelefone
	};

	// Faz uma chamada AJAX para enviar os dados para o servidor
	var xhr = new XMLHttpRequest();
	xhr.open("POST", "/Patient/NewTelephonePatient", true);
	xhr.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
	xhr.onreadystatechange = function () {
		switch (xhr.status) {
			case 200:
				$("#telID").val(xhr.responseText);
				toastr.success("Telefone adicionado á paciente com sucesso.");
				addNewRow(dataToSave);
				document.getElementById("btnStartCall").disabled = false;
				document.getElementById("btnStartCall").classList.remove("disabled");
				break;
			case 500:
				toastr.error("Algo deu errado, por favor, tente novamente.");
				break;
			case 204:
				toastr.info("Telefone e tipo de telefone são obrigatórios!");
				break;
			case 400:
				toastr.error(xhr.responseText);
				break;
		}
	};
	xhr.send(JSON.stringify(telephonesToAdd));
}

function addNewRow(dataToSave)
{
	var telephoneValue = document.querySelector("#add-phone-button").closest("tr").querySelector(".ipt-telephone").value;
	var typeValue = document.querySelector("#selectTypeTel").value;
	var obsValue = document.querySelector("#add-phone-button").closest("tr").querySelector(".ipt-obs").value;

	if (telephoneValue === "" || telephoneValue === null || typeValue === "" || typeValue === null)
		return;

	// Cria um novo elemento tr com os valores capturados
	var newRow = document.createElement("tr");
	newRow.classList.add("row-data");

	newRow.innerHTML = `
				<td class="data-cell">
					<div class="contents-details-person">
						<div class="eye-data">
							<svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-eye-fill" viewBox="0 0 16 16">
								<path d="M10.5 8a2.5 2.5 0 1 1-5 0 2.5 2.5 0 0 1 5 0z" />
								<path d="M0 8s3-5.5 8-5.5S16 8 16 8s-3 5.5-8 5.5S0 8 0 8zm8 3.5a3.5 3.5 0 1 0 0-7 3.5 3.5 0 0 0 0 7z" />
							</svg>
						</div>
						<div class="register-call-data">
							<svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-telephone" viewBox="0 0 16 16">
								<path d="M3.654 1.328a.678.678 0 0 0-1.015-.063L1.605 2.3c-.483.484-.661 1.169-.45 1.77a17.568 17.568 0 0 0 4.168 6.608 17.569 17.569 0 0 0 6.608 4.168c.601.211 1.286.033 1.77-.45l1.034-1.034a.678.678 0 0 0-.063-1.015l-2.307-1.794a.678.678 0 0 0-.58-.122l-2.19.547a1.745 1.745 0 0 1-1.657-.459L5.482 8.062a1.745 1.745 0 0 1-.46-1.657l.548-2.19a.678.678 0 0 0-.122-.58L3.654 1.328zM1.884.511a1.745 1.745 0 0 1 2.612.163L6.29 2.98c.329.423.445.974.315 1.494l-.547 2.19a.678.678 0 0 0 .178.643l2.457 2.457a.678.678 0 0 0 .644.178l2.189-.547a1.745 1.745 0 0 1 1.494.315l2.306 1.794c.829.645.905 1.87.163 2.611l-1.034 1.034c-.74.74-1.846 1.065-2.877.702a18.634 18.634 0 0 1-7.01-4.42 18.634 18.634 0 0 1-4.42-7.009c-.362-1.03-.037-2.137.703-2.877L1.885.511z" />
							</svg>
						</div>
					</div>
				</td>
				<td class="data-cell td-customize-new">
					<input type="tel" class="ipt-telephone customize-table-ipt unselectable" disabled value="${telephoneValue}" />
				</td>
				<td class="data-cell td-customize-new">
					<input class="select-type-telephone customize-table-ipt d-bd-none unselectable" disabled value="${typeValue}" />
				</td>
				<td class="data-cell td-customize-new">
					<textarea rows="4" cols="50" class="ipt-obs customize-table-ipt" disabled>${obsValue}</textarea>
				</td>
				<td colspan="5" style="border: none !important">
					<button class="btn btn-remove-telephone">
						<svg xmlns="http://www.w3.org/2000/svg" width="25" height="25" fill="currentColor" class="bi bi-x-circle" viewBox="0 0 16 16">
						  <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z"/>
						  <path d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z"/>
						</svg>
					</button>
				</td>
			`;

	// Adiciona a nova linha à tbody
	document.querySelector(".new-rows-added").appendChild(newRow);

	// Limpa os campos
	document.querySelector("#add-phone-button").closest("tr").querySelector(".ipt-telephone").value = "";
	document.querySelector("#add-phone-button").closest("tr").querySelector(".select-type-telephone").value = "null";
	document.querySelector("#add-phone-button").closest("tr").querySelector(".ipt-obs").value = "";

	// Adicionar o evento de remoção da linha ao botão
	var removeButton = newRow.querySelector(".btn-remove-telephone");
	removeButton.addEventListener("click", function () {
		try {
			deleteTelephone(document.getElementById("telID").value);

			var index = telephones.indexOf(dataToSave);

			if (index !== -1) {
				telephones.splice(index, 1);
			}

			newRow.remove();
		}
		catch (e) {
			console.error(e);
			return;
		}
	});
}

function deleteTelephone(id) {
	telephonesToAdd = {
		TelefoneID: document.getElementById("telID").value
	};

	// Faz uma chamada AJAX para enviar os dados para o servidor
	var xhr = new XMLHttpRequest();
	xhr.open("DELETE", "/Patient/RemoveTelephonePatient", true);
	xhr.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
	xhr.onreadystatechange = function () {
		switch (xhr.status) {
			case 200:
				toastr.info("Telefone removido com sucesso.");
				document.getElementById("btnStartCall").disabled = true;
				document.getElementById("btnStartCall").classList.add("disabled");
				break;
			case 500:
				toastr.error("Algo deu errado, por favor, tente novamente.");
				break;
			case 400:
				toastr.error(xhr.responseText);
				break;
		}
	};
	xhr.send(JSON.stringify(telephonesToAdd));
}

function SavePatient() {
	var radioButtons = document.querySelectorAll("input[name='qualificationCitizen']");

	// Itera pelos inputs radio para encontrar o selecionado
	var qC = "";
	for (var i = 0; i < radioButtons.length; i++) {
		if (radioButtons[i].checked) {
			qC = radioButtons[i].value;
			break;
		}
	}

	var nameIpt = document.getElementById("nameIpt").value;
	var birthDate = document.getElementById("birthDate").value;
	var unit = document.querySelector("select[name='unit']").value;
	var tA = document.querySelector("select[name='attendant-type']").value;
	var cpf = document.getElementById("cpf").value;
	var cns = document.getElementById("cns").value;
	var dum = document.getElementById("dum").value;
	var pf = document.getElementById("prevision-forecast").value;

	patientData = {
		PacienteNome: nameIpt,
		PacienteDataNascimento: birthDate,
		UnidadeAcompanhamentoID: parseInt(unit),
		TipoAtendimentoID: tA,
		QualificacaoMunicipeID: parseInt(qC),
		PacienteCPF: cpf,
		PacienteCNS: cns,
		DUM: dum,
		PrevisaoParto: pf
	};

	// Faz uma chamada AJAX para enviar os dados para o servidor
	var xhr = new XMLHttpRequest();
	xhr.open("POST", "/Patient/NewPatient", true);
	xhr.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
	xhr.onreadystatechange = function () {
		switch (xhr.status) {
			case 200:
				$(".register-telephone").show();
				$("#btnSavePatient").hide();
				$("#btnStartCall").show();
				toastr.success("Paciente criado com sucesso.");
				break;
			case 500:
				toastr.error("Algo deu errado, por favor, tente novamente.");
				break;
			case 204:
				toastr.info("Todos os campos são obrigatórios!");
				break;
			case 400:
				toastr.error(xhr.responseText);
				break;
		}
	};
	xhr.send(JSON.stringify(patientData));
}

function showComponent() {
	var x = document.getElementById("appComponent");
	if (x.style.display === "none") {
		x.style.display = "block";
	}
	else {
		x.style.display = "none";
	}
}

function nextDigit(input, cursorpos, isBackspace) {
	if (isBackspace) {
		for (let i = cursorpos - 1; i > 0; i--) {
			if (/\d/.test(input[i])) {
				return i
			}
		}
	}
	else {
		for (let i = cursorpos - 1; i < input.length; i++) {
			if (/\d/.test(input[i])) {
				return i
			}
		}
	}
	return cursorpos
}

function autoFormatWeight(ref) {
	try {
		let numberWeight = ref.value;
		var cleaned = ("" + numberWeight).replace(/\D/g, "");
		var match = cleaned.match(/^(\d{0,3})?/);
		return [
			match[1] ? "" : "",
			match[1],
			match[2] ? "" : " kg",
			match[2]
		].join("")
	}
	catch (err) {
		return "";
	}
}

function autoFormatHeight(ref) {
	try {
		let numberWeight = ref.value;
		var cleaned = ("" + numberWeight).replace(/\D/g, "");
		var match = cleaned.match(/^(\d{0,3})?/);
		return [
			match[1] ? "" : "",
			match[1],
			match[2] ? "" : " cm",
			match[2]
		].join("")
	}
	catch (err) {
		return "";
	}
}

function autoFormatPregnancies(ref) {
	try {
		let numberWeight = ref.value;
		var cleaned = ("" + numberWeight).replace(/\D/g, "");
		var match = cleaned.match(/^(\d{0,3})?/);
		return [
			match[1] ? "" : "",
			match[1],
			match[2] ? "" : " filho(s)",
			match[2]
		].join("")
	}
	catch (err) {
		return "";
	}
}

function cnsSearchChange(ref) {
	try {
		let cnsNumberString = ref.value
		var cleaned = ("" + cnsNumberString).replace(/\D/g, "");
		var match = cleaned.match(/^(\d{0,3})?(\d{0,4})?(\d{0,4})?(\d{0,4})?/);
		return [
			match[1] ? " " : "",
			match[1],
			match[2] ? " " : "",
			match[2],
			match[3] ? " " : "",
			match[3],
			match[4] ? " " : "",
			match[4]
		].join("")

	} catch (err) {
		return "";
	}
}

function performSearch(searchTerm, searchField) {
	$.ajax({
		url: '/Monitoring/MonitoringSearch',
		type: 'GET',
		data: { searchTerm: searchTerm, searchField: searchField },
		dataType: 'json',
		success: function (response) {
			$('#searchResults').html(response);
		},
		error: function (response) {
			if (response.status === 400) {
				toastr.error("Parece que estamos sem conexão com o banco de dados, por favor, aguarde.");
			}
		}
	});
}

function cnsSearchChange(ref) {
	try {
		let cnsNumberString = ref.value
		var cleaned = ("" + cnsNumberString).replace(/\D/g, "");
		var match = cleaned.match(/^(\d{0,3})?(\d{0,4})?(\d{0,4})?(\d{0,4})?/);
		return [
			match[1] ? " " : "",
			match[1],
			match[2] ? " " : "",
			match[2],
			match[3] ? " " : "",
			match[3],
			match[4] ? " " : "",
			match[4]
		].join("")

	} catch (err) {
		return "";
	}
}

function showComponent(componentName) {
	$.ajax({
		url: componentName,
		type: 'GET',
		success: function (data) {
			$("#component-container").html(data);
		}
	});
}

function nextDigit(input, cursorpos, isBackspace) {
	if (isBackspace) {
		for (let i = cursorpos - 1; i > 0; i--) {
			if (/\d/.test(input[i])) {
				return i
			}
		}
	}
	else {
		for (let i = cursorpos - 1; i < input.length; i++) {
			if (/\d/.test(input[i])) {
				return i
			}
		}
	}

	return cursorpos
}

function cnsChange(ref) {
	try {
		let cnsNumberString = ref.value
		var cleaned = ("" + cnsNumberString).replace(/\D/g, "");
		var match = cleaned.match(/^(\d{0,3})?(\d{0,4})?(\d{0,4})?(\d{0,4})?/);
		return [
			match[1] ? "" : "",
			match[1],
			match[2] ? " " : "",
			match[2],
			match[3] ? " " : "",
			match[3],
			match[4] ? " " : "",
			match[4]
		].join("")

	} catch (err) {
		return "";
	}
}

function cpfChange(ref) {
	try {
		let cpfNumberString = ref.value
		var cleaned = ("" + cpfNumberString).replace(/\D/g, "");
		var match = cleaned.match(/^(\d{0,3})?(\d{0,3})?(\d{0,3})?(\d{0,2})?/);
		return [
			match[1] ? "" : "",
			match[1],
			match[2] ? "." : "",
			match[2],
			match[3] ? "." : "",
			match[3],
			match[4] ? "-" : "",
			match[4]
		].join("")

	}
	catch (err) {
		return "";
	}
}

function autoFormatPhoneNumberRecado(ref) {
	try {
		let phoneNumberString = ref.value
		var cleaned = ("" + phoneNumberString).replace(/\D/g, "");
		var match = cleaned.match(/^(\d{0,2})?(\d{0,4})?(\d{0,4})?/);
		return [
			match[1] ? "(" : "",
			match[1],
			match[2] ? ") " : "",
			match[2],
			match[3] ? "-" : "",
			match[3]
		].join("")

	}
	catch (err) {
		return "";
	}
}

function autoFormatPhoneNumber(ref) {
	try {
		let phoneNumberString = ref.value
		var cleaned = ("" + phoneNumberString).replace(/\D/g, "");
		var match = cleaned.match(/^(\d{0,2})?(\d{0,1})?(\d{0,4})?(\d{0,4})?/);
		return [
			match[1] ? "(" : "",
			match[1],
			match[2] ? ") " : "",
			match[2],
			match[3] ? " " : "",
			match[3],
			match[4] ? "-" : "",
			match[4]
		].join("")

	}
	catch (err) {
		return "";
	}
}