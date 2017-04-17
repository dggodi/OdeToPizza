// otf.js

$(function () {

    var ajaxFormSubmit = function () {
        // ref to the form being submitted
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        // makes call back to server
        // - calls done method when it returns with the data form the server
        $.ajax(options).done(function (data) {

            // dom elemet to be updated with this data
            var $target = $($form.attr("data-otf-target"));
            var $newHtml = $(data);

            // replace this target with the returned html form server
            $target.replaceWith($newHtml);
            $newHtml.effect("highlight");
        });

        return false;
    };

    var submitAutocompleteForm = function (event, ui) {
        // get item selected from search in dropdown textbox
        var $input = $(this);
        $input.val(ui.item.label);

        // get the first form on the page
        var $form = $input.parents("form:first");
        $form.submit();
    };

    var createAutocomplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-otf-autocomplete"),
            select: submitAutocompleteForm
        };

        $input.autocomplete(options);
    };

    var getPage = function () {
        var $a = $(this);

        var options = {
            url: $a.attr("href"),
            data: $("form").serialize(),
            type: "get"
        };

        $.ajax(options).done(function (data) {
            var target = $a.parents("div.pagedList").attr("data-otf-target");
            $(target).replaceWith(data);
        });
        return false;

    };

    $("form[data-otf-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-otf-autocomplete]").each(createAutocomplete);

    $(".main-content").on("click", ".pagedList a", getPage);


});