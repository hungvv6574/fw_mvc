//an observable that retrieves its value when first bound
ko.onDemandObservable = function (callback, target) {
    var value = ko.observable();  //private observable

    var result = ko.computed({
        read: function () {
            //if it has not been loaded, execute the supplied function
            if (!result.loaded()) {
                callback.call(target);
            }
            //always return the current value
            return value();
        },
        write: function (newValue) {
            //indicate that the value is now loaded and set it
            result.loaded(true);
            value(newValue);
        },
        deferEvaluation: true  //do not evaluate immediately when created
    });

    //expose the current state, which can be bound against
    result.loaded = ko.observable();
    //load it again
    result.refresh = function () {
        result.loaded(false);
    };

    return result;
};

//an observable that retrieves its value when first bound
ko.onDemandObservableArray = function(callback, target) {
    var value = ko.observableArray(); //private observable

    var result = ko.dependentObservable({
        read: function() {
            //if it has not been loaded, execute the supplied function
            if (!result.loaded()) {
                callback.call(target);
                result.loaded(true);
            }
            //always return the current value
            return value();
        },
        write: function(newValue) {
            //indicate that the value is now loaded and set it
            result.loaded(true);
            value(newValue);
        },
        deferEvaluation: true  //do not evaluate immediately when created
    });

    //expose the current state, which can be bound against
    result.loaded = ko.observable();
    
    //load it again
    result.refresh = function() {
        result.loaded(false);
    };

    result.removeAll = function() {
        value.removeAll();
    };
    
    result.push = function (item) {
        value.push(item);
    };

    //expose the actual observableArray in case you need to operate on it
    result.actual = value;

    return result;
};

ko.bindingHandlers.fadeVisible = {
    init: function (element, valueAccessor) {
        // Initially set the element to be instantly visible/hidden depending on the value
        var value = valueAccessor();
        $(element).toggle(ko.utils.unwrapObservable(value)); // Use "unwrapObservable" so we can handle values that may or may not be observable
    },
    update: function (element, valueAccessor) {
        // Whenever the value subsequently changes, slowly fade the element in or out
        var value = valueAccessor();
        ko.utils.unwrapObservable(value) ? $(element).fadeIn() : $(element).fadeOut();
    }
};

ko.bindingHandlers.Click = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var init = $(element).data("click-event");
        if (!init) {
            var property = valueAccessor();
            ko.applyBindingsToNode(element, { click: property }, bindingContext.$parent);
            $(element).data("click-event", "1");
        }
    }
};

ko.bindingHandlers.safeClick = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        var init = $(element).data("click-event");
        if (!init) {
            var property = valueAccessor();
            ko.applyBindingsToNode(element, { click: property }, viewModel);
            $(element).data("click-event", "1");
        }
    }
};

ko.bindingHandlers.jsonDate = {
    update: function (element, valueAccessor, allBindingsAccessor) {
        var value = valueAccessor();
        if (!value || value.length == 0) {
            return;
        }

        var dt = new Date(parseInt(value.substr(6)));
        var format = allBindingsAccessor().jsonDateFormat;
        if (!format) {
            format = 0;
        }

        var shortMonthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
        var monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var leftPad = function (str, padString, length) {
            while (str.length < length)
                str = padString + str;
            return str;
        };

        switch (format) {
            case 0:
                $(element).html(dt.getDate() + ' ' + monthNames[dt.getMonth()] + ' ' + dt.getFullYear());
                break;
            case 1:
                $(element).html(dt.getDate() + ' ' + monthNames[dt.getMonth()] + ' ' + dt.getFullYear() + ' ' + dt.getHours() + ':' + dt.getMinutes() + ':' + dt.getSeconds());
                break;
            case 2:
                $(element).html(leftPad(dt.getDate().toString(), "0", 2) + ' ' + shortMonthNames[dt.getMonth()]);
                break;
            case 3:
                if (element.tagName == "input") {
                    $(element).val(dt.getMonth() + '/' + dt.getDate() + '/' + dt.getFullYear());
                } else {
                    $(element).html(leftPad((dt.getMonth() + 1).toString(), "0", 2) + '/' + leftPad(dt.getDate().toString(), "0", 2) + '/' + dt.getFullYear());
                }
                break;
            case 4:
                $(element).html(dt.getDate() + ' ' + monthNames[dt.getMonth()] + ' ' + dt.getFullYear() + ' ' + dt.getHours() + ':' + dt.getMinutes());
                break;
        }
    }
};

ko.bindingHandlers.jsonTime = {
    update: function (element, valueAccessor, allBindingsAccessor) {
        var value = valueAccessor();
        if (!value || value.length == 0) {
            return;
        }

        var dt = new Date(parseInt(value.substr(6)));
        var leftPad = function (str, padString, length) {
            while (str.length < length)
                str = padString + str;
            return str;
        };
        
        $(element).html(leftPad(dt.getHours().toString(), "0", 2) + ': ' + leftPad(dt.getMinutes().toString(), "0", 2) + ': ' + leftPad(dt.getSeconds().toString(), "0", 2));
    }
};

ko.bindingHandlers.convertjsonDate = {
    update: function (element, valueAccessor, allBindingsAccessor) {
        var value = $(element).val();
        if (!value || value.length == 0) {
            return;
        }

        var dt = new Date(parseInt(value.substr(6)));
        var format = allBindingsAccessor().jsonDateFormat;
        if (!format) {
            format = 0;
        }

        var shortMonthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
        var monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var leftPad = function (str, padString, length) {
            while (str.length < length)
                str = padString + str;
            return str;
        };

        switch (format) {
            case 0:
                $(element).html(dt.getDate() + ' ' + monthNames[dt.getMonth()] + ' ' + dt.getFullYear());
                break;
            case 1:
                $(element).html(dt.getDate() + ' ' + monthNames[dt.getMonth()] + ' ' + dt.getFullYear() + ' ' + dt.getHours() + ':' + dt.getMinutes() + ':' + dt.getSeconds());
                break;
            case 2:
                $(element).html(leftPad(dt.getDate().toString(), "0", 2) + ' ' + shortMonthNames[dt.getMonth()]);
                break;
            case 3:
                $(element).val((dt.getMonth() + 1) + '/' + dt.getDate() + '/' + dt.getFullYear());
                break;
            case 4:
                $(element).html(dt.getDate() + ' ' + monthNames[dt.getMonth()] + ' ' + dt.getFullYear() + ' ' + dt.getHours() + ':' + dt.getMinutes());
                break;
        }
    }
};

ko.bindingHandlers.jsDate = {
    update: function (element, valueAccessor, allBindingsAccessor) {
        var value = valueAccessor();
        if (!value || value.length == 0) {
            return;
        }

        var dt = value;
        var format = allBindingsAccessor().jsonDateFormat;
        if (!format) {
            format = 0;
        }

        var shortMonthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
        var monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var leftPad = function (str, padString, length) {
            while (str.length < length)
                str = padString + str;
            return str;
        };

        switch (format) {
            case 0:
                $(element).html(dt.getDate() + ' ' + monthNames[dt.getMonth()] + ' ' + dt.getFullYear());
                break;
            case 1:
                $(element).html(dt.getDate() + ' ' + monthNames[dt.getMonth()] + ' ' + dt.getFullYear() + ' ' + dt.getHours() + ':' + dt.getMinutes() + ':' + dt.getSeconds());
                break;
            case 2:
                $(element).html(leftPad(dt.getDate().toString(), "0", 2) + ' ' + shortMonthNames[dt.getMonth()]);
                break;
            case 3:
                $(element).val(dt.getMonth() + '/' + dt.getDate() + '/' + dt.getFullYear());
                break;
            case 4:
                $(element).html(dt.getDate() + ' ' + monthNames[dt.getMonth()] + ' ' + dt.getFullYear() + ' ' + dt.getHours() + ':' + dt.getMinutes());
                break;
        }
    }
};

ko.bindingHandlers.datePicker = {
    init: function (element, valueAccessor) {
        var options = {
            minDate: 0,
            onSelect: function (dateText) {
                var value = valueAccessor();
                if ($.isFunction(value)) {
                    value(dateText);
                }
            }
        };
        
        $(element).datepicker(options);
    }
};

ko.bindingHandlers.editAvatar = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        var id = "btn" + new Date().getTime();
        $(element).attr("id", id);

        var options = allBindingsAccessor().editAvatarOptions || { };
        var uploader = new plupload.Uploader({
            runtimes: 'html5,html4',
            browse_button: id,
            url: options.url + '?customerId=' + options.customerId,
            filters: [{ extensions: options.extensions }]
        });
        uploader.init();

        uploader.bind("FilesAdded", function () {
            uploader.start();
        });

        uploader.bind("FileUploaded", function () {
            var src = ko.utils.unwrapObservable(valueAccessor());
            if (src && src.length > 0) {
                if (src.indexOf("?") > 0) {
                    src += "&t=" + new Date().getTime();
                } else {
                    src += "?t=" + new Date().getTime();
                }
                var value = valueAccessor();
                value(src);
            }
        });
    }
};

ko.bindingHandlers.uniqueId = {
    init: function (element, valueAccessor) {
        var value = valueAccessor();
        if (!value.id) {
            element.id = ko.bindingHandlers.uniqueId.prefix + (++ko.bindingHandlers.uniqueId.counter);
        } else {
            element.id = value.id;
        }
    },
    counter: 0,
    prefix: "unique"
};

ko.bindingHandlers.uniqueNameWithPrefix = {
    init: function (element, valueAccessor) {
        var prefix = valueAccessor();
        element.name = prefix + "$" + (++ko.bindingHandlers.uniqueNameWithPrefix.counter);
        if (ko.utils.isIe6 || ko.utils.isIe7)
            element.mergeAttributes(document.createElement("<input name='" + element.name + "'/>"), false);
    },
    counter: 0
};

ko.bindingHandlers['uniqueNameWithPrefix'].currentIndex = 0;

ko.smartObservable = function (initialValue, functions) {
    var temp = initialValue;
    var value = ko.observable(initialValue);

    var result = ko.computed({
        read: function () { return value(); },
        write: function (newValue) {
            var shouldUpdate = true;
            temp = newValue;
            if (functions) {
                for (var i = 0; i < functions.length; i++) {
                    if (shouldUpdate && typeof (functions[i]) == "function")
                        shouldUpdate = functions[i](newValue);
                    if (!shouldUpdate) break;
                }
            }
            if (shouldUpdate) {
                if (temp !== value()) value(temp);
            }
            else {
                value.valueHasMutated();
                temp = value();
            }
        }
    });
    return result;
};

function isNumeric(s) {
    return parseInt(s, 10).toString() === s.toString();
}

ko.bindingHandlers.menu = {
    init: function(element) {
        var pathname = window.location.pathname.toLowerCase();
        $(element).each(function () {
            $("a", this).each(function() {
                var href = $(this).attr("href");
                if (href && href.toLowerCase() == decodeURIComponent(pathname)) {
                    $(this).parent().addClass("active");
                    return false;
                }
                return true;
            });
        });
    }
};

ko.bindingHandlers.calendar = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        var value = valueAccessor();
        var dt = value();

        if (!dt) {
            dt = new Date();
            value(dt);
        }
        
        $(".prev_btn").click(function() {
            var x = $(element).datepicker();
            $.datepicker._adjustDate(x, -1, 'M');
        });
        
        $(".next_btn").click(function() {
            var x = $(element).datepicker();
            $.datepicker._adjustDate(x, 1, 'M');
        });

        var options = {};

        options.onSelect = function(dateText) {
            var day = new Date(dateText);
            value(day);
        };

        var allBindings = allBindingsAccessor();
        if (allBindings.onChangeMonthYear) {
            options.onChangeMonthYear = function (year, month) {
                allBindings.onChangeMonthYear(year, month);
            };
        }
        
        $(element).datepicker(options);
    }
};

ko.bindingHandlers.confirm = {
    init: function (element, valueAccessor) {
        var value = valueAccessor();
        var msg = ko.utils.unwrapObservable(value);
        $(element).click(function (event) {
            if (!confirm(msg)) {
                event.stopImmediatePropagation();
                return false;
            }
            return true;
        });
    }
};

ko.bindingHandlers.modal = {
    init: function (element) {
        var $target = $("#dlgGenericModal");
        if ($target.length == 0) {
            $("<div id='dlgGenericModal' class='modal hide fade' tabindex='-1' role='dialog' aria-hidden='true'><div class='modal-header'><button type='button' class='close' data-dismiss='modal' aria-hidden='true'>×</button><h3>Modal</h3></div><div class='modal-body' style='padding:0;max-height:none;overflow-y:hidden;'></div><div class='modal-footer'></div></div>").appendTo(document.body);
            $target = $("#dlgGenericModal");

            $target.modal({ show: false });
        }
        
        $(element).click(function (event) {
            var href = $(element).attr("href");
            if (href && href.length > 0 && href.indexOf("#") != 0) {
                event.preventDefault();

                var width = ($(element).data("width") || "").toString();
                
                if (width.length > 0) {
                    var widthValueUnit = width.indexOf("%") > 0 ? "%" : "px";
                    var widthValue = parseInt(width.replace("px", "").replace("%", ""));
                    $target.css("width", widthValue + widthValueUnit).css("margin-left", "-" + (widthValue/2) + widthValueUnit);
                } else {
                    $target.css("width", "600px").css("margin-left", "-300px");
                }
                
                window.setModalTitle = function (title) {
                    $('.modal-header h3', $target).html(title);
                };
                $('.modal-body', $target).html('<iframe src="' + href + '" frameborder="0" width="100%" seamless onload="window.setModalTitle(this.contentWindow.document.title); var $height = this.contentWindow.document.body.scrollHeight; if($height > 450){ $height = 450; } if($height <= 0) { $height = 450; } this.height = $height;"></iframe>');
                $target.modal("show");
                return false;
            }
            return true;
        });
    }
};

ko.bindingHandlers.autoComplete = {
    update: function(element, valueAccessor, allBindingsAccessor) {
        var postUrl = allBindingsAccessor().source; // url to post to is read here
        var value = valueAccessor();
        if (value) {
            $(element).autocomplete({
                minLength: 2,
                autoFocus: true,
                source: function(request, response) {
                    $.ajax({
                        url: postUrl,
                        data: { name: request.term },
                        dataType: "json",
                        type: "GET",
                        success: function(data) {
                            response($.map(data.Data, function(v, i) {
                                return {
                                    label: v.label,
                                    value: v.label
                                };
                            }));
                        }
                    });

                },
            });
        }
    }
};

ko.bindingHandlers.hasFocus = {
    init: function (element, valueAccessor) {
        $(element).focus(function () {
            //ar value = valueAccessor();
            // value(true);
            $(this).next(".show-message-error").css("display", "block");
        });
        $(element).blur(function () {
            $(this).next(".show-message-error").css("display", "none");
        });
    },
    update: function (element, valueAccessor) {
        var value = valueAccessor();
        if (ko.unwrap(value))
            element.focus();
        else
            element.blur();
    }
};