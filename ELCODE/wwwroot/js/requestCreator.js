var clientId = $(location).attr('href').split("=")[1];

$('#request').change(function () {
    if ($(this).val() == "Новый запрос") return false;

	$.ajax({
		type: "GET",
		url: "/Elcode/GetRequests",
		data: { clientId },
		success: function (requests) {
			for (var i = 0; i < requests.length; i++)
				$('#requests').append('<option value="' + requests[i].id + '">' + requests[i].creationDate + '</option>');

			if (requests.length > 0) {
				var requests = document.getElementById(`requests`);
				$(requests).css('display', 'block');
            }
		}
	});
});

function AddRequest() {
	var requestTypeId = $('#requestType').val();
	var description = $('#description').val();
	var channelId = $('#channel').val();
	var mainRequestId = $('#requests').val();
	$.ajax({
		type: "POST",
		url: "/Elcode/AddRequest",
		data: { clientId, requestTypeId, description, channelId, mainRequestId }
	});
}