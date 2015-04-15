function documentReady(root, controller, action) {

    //bind the window min-height to window size
    adjustLayout();
    $(window).on('resize', adjustLayout);

    consistentSearchTxt();

   


    //parsing the unobtrusive attributes when we get content via ajax
    $(document).ajaxComplete(function () {
        $.validator.unobtrusive.parse(document);
        //make server-side generated validation errors look like the client side ones
        $('.field-validation-error').each(function () {
            if (!$(this).find('span').length) {
                var x = $(this).html();
                $(this).html('<span>' + x + '</span>');
            }
        });
    });
}

function init(dateFormat, isMobileOrTablet) {
    //by default jquery.validate doesn't validate hidden inputs
    if ($.validator) $.validator.setDefaults({
        ignore: []
    });

    setjQueryValidateDateFormat(dateFormat);

    // don't focus first input on mobile
    if (isMobileOrTablet) {
        awe.ff = function (o) {
            o.p.d.find(':tabbable').blur();//override jQueryUI dialog autofocus
        };
    }

    //awesome error handling
    awe.err = function (o, xhr, textStatus, errorThrown) {
        var msg = "unexpected error occured";
        if (xhr) {
            msg = xhr.responseText;
        }
        var btnHide = $('<button type="button"> hide </button>').click(function () {
            $(this).parent().remove();
        });

        var c = $('<div/>').html(msg).append(btnHide);

        if (o.p && o.p.isOpen) {
            o.p.d.prepend(c);
        } else if (o.f) {
            o.f.html(c);
        } else if (o.d) {
            o.d.after(c);
        } else $('body').prepend(c);
    };
}

// on ie hitting enter doesn't trigger change, 
// all searchtxt inputs will trigger change on enter in all browsers
function consistentSearchTxt() {
    $('.searchtxt').each(function () {
        if ($(this).data('searchtxth') != 1)
            $(this).data('searchtxth', 1)
                .data('myval', $(this).val())
                .on('change', function (e) {
                    if ($(this).val() != $(this).data('myval')) {
                        $(this).data('myval', $(this).val());
                    } else {
                        e.stopImmediatePropagation();
                    }
                })
                .on('keyup', function (e) {
                    if (e.which == 13) {
                        e.preventDefault();
                        if ($(this).val() != $(this).data('myval')) {

                            $(this).change();
                        }
                    }
                });
    });
}

// crud related
function itemDeleted(gridId) {
    return function (res) {
        var $grid = $("#" + gridId);
        $grid.data('api').select(res.Id)[0].fadeOut(500, function () {
            var posibnest = $(this).next();
            if (posibnest.is(".awe-nest")) {
                posibnest.remove();
            }
            $(this).remove();
            if (!$grid.find('.awe-row').length) $grid.data('api').load();
        });
    };
}

function itemUpdated(gridId) {
    return function (item) {
        var api = $('#' + gridId).data('api');
        var xhr = api.update(item.Id);
        $.when(xhr).done(function () {
            var $row = api.select(item.Id)[0];
            var altcl = $row.hasClass("awe-alt") ? "awe-alt" : "";
            $row.switchClass(altcl, "awe-changing", 1).switchClass("awe-changing", altcl, 1000);
            var posibnest = $row.next();
            if (posibnest.is(".awe-nest")) {
                posibnest.remove();
            }
        });
    };
}

function itemCreated(gridId) {
    return function (item) {
        var $grid = $("#" + gridId);
        var $row = $grid.data('api').renderRow(item);
        $grid.find(".awe-tbody").prepend($row);
        $row.addClass("awe-changing").removeClass("awe-changing", 1000);
    };
}

function deleteFormat(popupName, gridId) {
    return function (model) {
        if (model.IsDeleted) {
            return "<button type='button' class='awe-btn' onclick=\"restore('" + gridId + "'," + model.Id + ")\"><span class='ico-restore'></span></button>";
        }

        return "<button type='button' class='awe-btn' onclick=\"awe.open('" + popupName + "', { params:{ id: " + model.Id + " } })\"><span class='ico-del'></span></button>";
    };
}

function restore(gridId, id) {
    $('#' + gridId).data('api').update(id, { restore: true });
}


function itemCreatedAl(ajaxListId, lookupId) {
    return function (o) {
        var container = lookupId ? $('#' + lookupId + "-awepw .awe-srl") : $('#' + ajaxListId);
        container.prepend($.trim(o.Content));
    };
}

function itemUpdatedAl(ajaxListId, func, lookupId) {
    return function (o) {
        getContainer(ajaxListId, lookupId).find('[data-k=' + o.Id + ']').fadeOut(300, function () {
            $(this).after($.trim(o.Content)).remove();
            if (func) func();
        });
    };
}

function itemDeletedAl(ajaxListId, lookupId) {
    return function (o) {
        getContainer(ajaxListId, lookupId).find("[data-k=" + o.Id + "]").fadeOut(300, function () { $(this).remove(); });
    };
}

function getContainer(ajaxListId, lookupId) {
    return lookupId ? $('#' + lookupId + "-awepw .awe-srl") : $('#' + ajaxListId);
}

function passchanged(o) {
    $("<div> password for " + o.Login + " was successfuly changed </div>").dialog();
}



function adjustLayout() {
    $("#main").css("min-height", ($(window).height() - 120) + "px");
}

function setjQueryValidateDateFormat(format) {
    //setting the correct date format for jquery.validate
    jQuery.validator.addMethod(
        'date',
        function (value, element, params) {
            if (this.optional(element)) {
                return true;
            };
            var result = false;
            try {
                $.datepicker.parseDate(format, value);
                result = true;
            } catch (err) {
                result = false;
            }
            return result;
        },
        ''
    );
}

//google analytics
var _gaq = _gaq || [];
_gaq.push(['_setAccount', 'UA-27119754-1']);
_gaq.push(['_setDomainName', 'dejavu.com']);
_gaq.push(['_trackPageview']);
(function () {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
})();