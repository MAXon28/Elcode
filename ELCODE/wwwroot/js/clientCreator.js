function AddClient() {
	var name = $('#client').val();
	var importanceId = $('#importance').val();
	$.ajax({
		type: "POST",
		url: "/Elcode/AddClient",
		data: { name, importanceId }
	});
}