//inline popup mod
function inlinePopup(o) {
    var p = o.p; //popup properties
    var popup = p.d; //popup div
    var wrap = $('<div class="wrap"></div>').hide();

    //minimum height of the lookup/multilookup content
    p.mlh = 250;

    wrap.append(popup);

    //decide where to attach the inline popup
    //tag and tags are set using .Tag(object) .Tags(string)
    if (o.tag && o.tag.target) {
        $('#' + o.tag.target).append(wrap);
    } else if (o.tag && o.tag.cont) {// cont used in grid nesting
        o.tag.cont.append(wrap);
    } else if (o.tags) {
        $('#' + o.tags).append(wrap);
    } else if (o.f) { //component field
        o.f.after(wrap);
    } else {
        $('body').prepend(wrap);
    }

    var api = function () { };
    api.open = function () {
        wrap.show();
        p.isOpen = 1;
    };
    api.close = function () {
        wrap.hide();
        p.isOpen = 0;
        if (p.cl) {
            p.cl();
        }
        popup.trigger('aweclose');
        if (!p.dntr) {
            wrap.remove();
        }
    };
    api.destroy = function () {
        api.close();
        wrap.remove();
    };

    popup.data('api', api);

    var title = $('<div class="inl-title"></div>');
    var closeBtn = $('<button type="button" class="awe-btn">&nbsp;X&nbsp;</button>').click(api.close);
    title.append(closeBtn).append("<span class='inl-txt'>" + p.t + "</span>");

    if (!(o.tag && o.tag.NoTitle))
    wrap.prepend(title);

    // add btns if any
    if (p.btns) {
        var footer = $('<div></div>');
        wrap.append(footer);
        $.each(p.btns, function (i, e) {
            var btn = $('<button type="button" class="awe-btn inl-btn">' + e.text + '</button>');
            btn.click(function () { e.click.call(popup); });
            footer.append(btn);
        });
    }

    return wrap;
}