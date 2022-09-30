$(function () {
    $("#confirm").click(function () {
        var result = $.confirm({
            'title': 'JavaScriptでConfirmをカスタマイズする方法',
            'message': 'jQuery.confirmで表現しています',
            'buttons': {
                OK: {
                    action: function () {
                        console.log("OK");
                        return true;
                    }
                },
                NO: {
                    btnClass: 'btn-blue',
                    keys: ['enter'],
                    action: function () {
                        console.log("NO");
                    }
                }
            }
        });
    });
    alert(result)
});

function confirm_dc() {
    var result = $.confirm({
        'title': 'JavaScriptでConfirmをカスタマイズする方法',
        'message': 'jQuery.confirmで表現しています',
        'buttons': {
            OK: {
                action: function () {
                    console.log("OK");
                    return true;
                }
            },
            NO: {
                btnClass: 'btn-blue',
                keys: ['enter'],
                action: function () {
                    console.log("NO");
                }
            }
        }
    });
}