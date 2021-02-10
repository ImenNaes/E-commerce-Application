// timer
!function (t, n) { "object" == typeof exports && "undefined" != typeof module ? module.exports = n() : "function" == typeof define && define.amd ? define(n) : t.Timer = n() }(this, function () { "use strict"; function s(t, n, e) { var o = void 0, i = ""; if (t.length > n) return t; for (o = 0; o < n; o += 1)i += String(e); return (i + t).slice(-i.length) } function P() { this.secondTenths = 0, this.seconds = 0, this.minutes = 0, this.hours = 0, this.days = 0, this.toString = function (t, n, e) { t = t || ["hours", "minutes", "seconds"], n = n || ":", e = e || 2; var o = [], i = void 0; for (i = 0; i < t.length; i += 1)void 0 !== this[t[i]] && ("secondTenths" === t[i] ? o.push(this[t[i]]) : o.push(s(this[t[i]], e, "0"))); return o.join(n) } } var t = "undefined" != typeof window ? window.CustomEvent : void 0; "undefined" != typeof window && "function" != typeof t && ((t = function (t, n) { n = n || { bubbles: !1, cancelable: !1, detail: void 0 }; var e = document.createEvent("CustomEvent"); return e.initCustomEvent(t, n.bubbles, n.cancelable, n.detail), e }).prototype = window.Event.prototype, window.CustomEvent = t); var q = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function (t) { return typeof t } : function (t) { return t && "function" == typeof Symbol && t.constructor === Symbol && t !== Symbol.prototype ? "symbol" : typeof t }, I = "secondTenths", O = "seconds", z = "minutes", R = "hours", B = "days", F = { secondTenths: 100, seconds: 1e3, minutes: 6e4, hours: 36e5, days: 864e5 }, G = { secondTenths: 10, seconds: 60, minutes: 60, hours: 24 }, H = "undefined" != typeof module && module.exports && "function" == typeof require ? require("events") : void 0; function J() { return "undefined" != typeof document } function K() { return H } function N(t, n) { return (t % n + n) % n } return function () { var s = new P, r = new P, i = void 0, e = J() ? document.createElement("span") : K() ? new H.EventEmitter : void 0, u = !1, d = !1, c = void 0, a = void 0, f = void 0, v = {}, h = void 0, l = void 0, p = void 0, m = void 0, y = void 0, o = void 0, b = { detail: { timer: this } }; function w(t, n) { var e, o, i = r[n]; return o = U(t, F[e = n]), r[e] = o, s[e] = e === B ? o : 0 <= o ? N(o, G[e]) : G[e] - N(o, G[e]), r[n] !== i } function t() { n(), function () { for (var t in s) s.hasOwnProperty(t) && "number" == typeof s[t] && (s[t] = 0); for (var n in r) r.hasOwnProperty(n) && "number" == typeof r[n] && (r[n] = 0) }() } function n() { clearInterval(i), i = void 0, d = u = !1 } function g(t) { var n, e, o; M() ? (y = E(), l = V(h.target)) : (c = "string" == typeof (e = (e = t) || {}).precision ? e.precision : O, f = "function" == typeof e.callback ? e.callback : function () { }, m = !0 === e.countdown, a = !0 === m ? -1 : 1, "object" === q(e.startValues) ? (o = e.startValues, p = L(o), s.secondTenths = p[0], s.seconds = p[1], s.minutes = p[2], s.hours = p[3], s.days = p[4], r = A(p, r)) : p = null, y = E(), S(), "object" === q(e.target) ? l = V(e.target) : m ? (e.target = { seconds: 0 }, l = V(e.target)) : l = null, v = { precision: c, callback: f, countdown: "object" === (void 0 === e ? "undefined" : q(e)) && !0 === e.countdown, target: l, startValues: p }, h = e), n = F[c], C(j(Date.now())) || (i = setInterval(T, n), d = !(u = !0)) } function E() { return j(Date.now()) - r.secondTenths * F[I] * a } function T() { var t, n = j(Date.now()); (t = S())[I] && k("secondTenthsUpdated", b), t[O] && k("secondsUpdated", b), t[z] && k("minutesUpdated", b), t[R] && k("hoursUpdated", b), t[B] && k("daysUpdated", b), f(b.detail.timer), C(n) && (D(), k("targetAchieved", b)) } function S() { var t = 0 < arguments.length && void 0 !== arguments[0] ? arguments[0] : j(Date.now()), n = 0 < a ? t - y : y - t, e = {}; return e[I] = w(n, I), e[O] = w(n, O), e[z] = w(n, z), e[R] = w(n, R), e[B] = w(n, B), e } function j(t) { return Math.floor(t / F[c]) * F[c] } function C(t) { return l instanceof Array && o <= t } function L(t) { var n, e, o, i, s, r = void 0; if ("object" === (void 0 === t ? "undefined" : q(t))) if (t instanceof Array) { if (5 !== t.length) throw new Error("Array size not valid"); r = t } else r = [t.secondTenths || 0, t.seconds || 0, t.minutes || 0, t.hours || 0, t.days || 0]; return n = r[0], e = r[1] + U(n, 10), o = r[2] + U(e, 60), i = r[3] + U(o, 60), s = r[4] + U(i, 24), r[0] = n % 10, r[1] = e % 60, r[2] = o % 60, r[3] = i % 24, r[4] = s, r } function U(t, n) { var e = t / n; return e < 0 ? Math.ceil(e) : Math.floor(e) } function V(t) { if (t) { var n = A(l = L(t)); return o = y + n.secondTenths * F[I] * a, l } } function A(t, n) { var e = n || {}; return e.days = t[4], e.hours = 24 * e.days + t[3], e.minutes = 60 * e.hours + t[2], e.seconds = 60 * e.minutes + t[1], e.secondTenths = 10 * e.seconds + t[[0]], e } function D() { t(), k("stopped", b) } function k(t, n) { J() ? e.dispatchEvent(new CustomEvent(t, n)) : K() && e.emit(t, n) } function x() { return u } function M() { return d } void 0 !== this && (this.start = function (t) { x() || (g(t), k("started", b)) }, this.pause = function () { n(), d = !0, k("paused", b) }, this.stop = D, this.reset = function () { t(), g(h), k("reset", b) }, this.isRunning = x, this.isPaused = M, this.getTimeValues = function () { return s }, this.getTotalTimeValues = function () { return r }, this.getConfig = function () { return v }, this.addEventListener = function (t, n) { J() ? e.addEventListener(t, n) : K() && e.on(t, n) }, this.removeEventListener = function (t, n) { J() ? e.removeEventListener(t, n) : K() && e.removeListener(t, n) }) } });


//// details

//// List
//var ProductsFilterModel = {
//    "ProductCategoryID": '00000000-0000-0000-0000-000000000000',
//    "ProductTypeID": '00000000-0000-0000-0000-000000000000',
//    "Pagenumber": 1,
//    "Skip": 0,
//    "EndPrice": 0,
//    "StartPrice": 0,
//    "Colors": [],
//    "Sizes": [],
//    "Units": [],
//    "Brands": [],
//    "Condition": [],
//    "ProductDetailsTypesDetailsList": [],
//    "PlaceID": '',
//    "dateFrom": '',
//    "dateTo": '',
//};
//var urlShopPartial;
//var isLoading = false;
//var NotFoundCount = 0;
//var text1, text2, errorTickettitle;
//function FilteredProducts(type) {
//    if (document.querySelector('input[name="ProductTypesID"]:checked') != null) {
//        ProductsFilterModel.ProductTypeID = document.querySelector('input[name="ProductTypesID"]:checked').value;
//    } else {
//        ProductsFilterModel.ProductTypeID = '00000000-0000-0000-0000-000000000000';
//    }
//    if ($("#Place").val() != "Nothing") { ProductsFilterModel.PlacesID = $("#Place").val(); }
//    if ($('#datepickerFrom').val() != "") {
//        ProductsFilterModel.StartDate = $('#datepickerFrom').val();
//    }
//    else {
//        ProductsFilterModel.StartDate = null;
//    }
//    if ($('#datepickerTo').val() != "") {
//        ProductsFilterModel.EndDate = $('#datepickerTo').val();
//    }
//    else {
//        ProductsFilterModel.EndDate = null;
//    }

//    ProductsFilterModel.StartPrice = $('#min-field').val();
//    ProductsFilterModel.EndPrice = $('#max-field').val();

//    var radios = document.getElementsByClassName("ProductTypesID");
//    for (i = 0; i < radios.length; i++) {
//        if (radios[i].checked) {
//            ProductsFilterModel.ProductTypeID = radios[i].value;
//        }
//    } isLoading = true;
//    ProductsFilterModel.ProductCategoryID = type;
//    var _type = type;
//    if (type == undefined) {
//        ProductsFilterModel.Pagenumber = 1;
//        $('#productsPartialList').empty();
//    };
//    $('#customloader').css('display', 'flex');
//    $('[class="categories"]').css('pointer-events', 'none');
//    $.ajax({
//        type: 'POST',
//        url: urlShopPartial,
//        contentType: "application/json; charset=utf-8",
//        data: JSON.stringify({ 'SelectedFilters': ProductsFilterModel }),
//        success: function (data) {
//            if (data != "NotFound") {
//                $('[class="categories"]').css('pointer-events', '');
//                var divContainer = $('#productsPartialList');
//                divContainer.append(data);
//                isLoading = false;
//                NotFoundCount = 0;
//                $('#total').html($('#resultPartial').val())
//            }
//            else {
//                NotFoundCount = NotFoundCount + 1;
//                //console.log(NotFoundCount);
//                if (NotFoundCount => 1) {
//                    $("#addmore").hide();
//                    $('#forfilteredproductserror').append('<br> <div class="empty-tickets-block">' +
//                        '<div class="mistake">' +
//                        '<p>' + text1 + '</p>' +
//                        '<h1>' + text2 + '</h1>' +
//                        '</div>' +
//                        '</div > <br />');

//                    if (typeof $('#resultPartial').val() === 'undefined' || $('#resultPartial').val() === null) {
//                        $('#total').html('0');
//                    } else {
//                        $('#total').html(parseInt($('#resultPartial').val()));
//                    }
//                }
//            }
//        },
//        error: function (xhr, desc, err) {
//        },
//        beforeSend: function () {
//            // Show image container
//            $("#loader").show();
//        },
//        complete: function (data) {
//            // Hide image container
//            $("#loader").hide();
//        }
//    });
//}

//function FilterSubmit() {
//    $('#total').val(0);
//    ProductsFilterModel.Pagenumber = 1;
//    ProductsFilterModel.Brands = [];
//    ProductsFilterModel.Sizes = [];
//    ProductsFilterModel.Colors = [];
//    ProductsFilterModel.Units = [];
//    ProductsFilterModel.Condition = [];
//    ProductsFilterModel.PlacesID = '';
//    if ($("#Place").val() != "Nothing") { ProductsFilterModel.PlacesID = $("#Place").val(); }
//    if ($('#datepickerFrom').val() != "") {
//        ProductsFilterModel.StartDate = $('#datepickerFrom').val();
//    }
//    else {
//        ProductsFilterModel.StartDate = null;
//    }
//    if ($('#datepickerTo').val() != "") {
//        ProductsFilterModel.EndDate = $('#datepickerTo').val();
//    }
//    else {
//        ProductsFilterModel.EndDate = null;
//    }

//    ProductsFilterModel.StartPrice = $('#min-field').val();
//    ProductsFilterModel.EndPrice = $('#max-field').val();

//    var radios = document.getElementsByClassName("ProductTypesID");
//    for (i = 0; i < radios.length; i++) {
//        if (radios[i].checked) {
//            ProductsFilterModel.ProductTypeID = radios[i].value;
//        }
//    }
//    var divContainer = $('#productsPartialList');
//    $('#forfilteredproductserror').html("");
//    divContainer.html(" <br />");
//    FilteredProducts(ProductsFilterModel.ProductCategoryID);
//}

//var isLoading = false;

//$(document).ready(function () {
//    $('#submitfilter').click(function () {
//        $("#addmore").show();
//        FilterSubmit();
//    });
//    $('#addmore').click(function () {
//        ProductsFilterModel.Pagenumber += 1
//        FilteredProducts(ProductsFilterModel.ProductCategoryID);
//    });
//});

// Create
