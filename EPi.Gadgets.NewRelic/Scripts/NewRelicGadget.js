(function ($) {
    newrelicgadget = {
        init: function (e, gadget) {
            $(gadget.element).bind("epigadgetloaded", function (e, gadget) {

                if (gadget.routeParams.controller == 'NewRelicGadget' | gadget.routeParams.action == 'ShowServerStatus') {
                    $.ajax({
                        url: '//www.google.com/jsapi',
                        dataType: 'script',
                        cache: true,
                        async: true,
                        success: function () {
                            google.load('visualization', '1', {
                                'packages': ['gauge'],
                                'callback': drawChart
                            });
                            dijit.byNode($(gadget.element).closest(".epi-gadgetContainer")[0]).resize({ h: 560 });
                        }
                    });
                }
            });
        }
    };
})(epiJQuery);