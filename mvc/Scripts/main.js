function reload(html){
			if(html == undefined){
				$.get("/Home/Get", function(data){
					reload(data);
				})
			}else{
				$('#data').html(html);
			}
		}	
	
		$(function() {
			reload();
	        $("#add").submit(function() {
	        	var form = $(this);
	            $.post(form.attr('action'), form.serialize(), function(data){reload(data);});
	            
	            return false;
	        });
	    });