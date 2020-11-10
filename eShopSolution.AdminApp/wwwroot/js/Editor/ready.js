ClassicEditor
	.create(document.querySelector('#editor-details'), {
		// toolbar: [ 'heading', '|', 'bold', 'italic', 'link' ]
	})
	.then(editor => {
		window.editor = editor;
	})
	.catch(err => {
		console.error(err.stack);
	});