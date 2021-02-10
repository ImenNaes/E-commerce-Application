var subscriptionsmsgsuccess, subscriptionsmsgExist, subscriptionsmsgerror;
$('#emailsubscription').submit(function (e) {
    var _form = $('#emailsubscription');
    var action = _form.attr('action')
    e.preventDefault();
    if (_form.valid()) {
        $.ajax({
            url: action,
            data: _form.serialize(),
            success: function (data) {
                if (data == "Success") {
                    $('#subscriptionsmsg').empty().html(subscriptionsmsgsuccess);
                    $('#emailsubscription #_Email').val('');
                }
                else if (data == "Exist") {
                    $('#subscriptionsmsg').empty().html(subscriptionsmsgExist);
                }
            },
            error: function () {
                $('#subscriptionsmsg').empty().html(subscriptionsmsgerror);
            }
        });
    }
});
$("#emailSubs").on("keyup", function () {
    $('#subscriptionsmsg').text("");
});



// Create 

 
function LoadSubsProductTypes() {
    var ProductTypes = $("#ProductTypesID option:selected").text();
    var subProductTypes = $("#subProductTypesID option:selected").text();
    document.getElementById("ItemName").value = ProductTypes + " " + subProductTypes;
}

var urlShowSubProductTypes;
function LoadProductTypes() {
    var x = document.getElementById("ProductTypesID").value;
    $.ajax
        ({
            type: 'GET',
            url: urlShowSubProductTypes,
            data: { MainProductCategoriesID: x },
            success: function (data) {
                if (data != 'Error') {
                    $('#subProductTypesID').html(data);
                    $('#subProductTypesID').niceSelect('update');

                } else {
                    alert("Error");
                }
            },
            error: function (ex) {
            }
        });
}
function LoadSubsProductTypes() {
    var ProductTypes = $("#ProductTypesID option:selected").text();
    var subProductTypes = $("#subProductTypesID option:selected").text();
    document.getElementById("ItemName").value = ProductTypes + " " + subProductTypes;
}

var ProductTypesID, subProductTypesID;

$('#ProductTypesID option').removeAttr('selected').filter('[value= ' + ProductTypesID +']').attr('selected', true);
$('#subProductTypesID option').removeAttr('selected').filter('[value= ' + subProductTypesID+']').attr('selected', true);
$(document).ready(function () {
    $(' .nice-select.ProductTypesID ul li').click(function () {
        $('#ProductTypesID option').removeAttr('selected').filter('[value=' + $(this).attr('data-value') + ']').attr('selected', true);
    });
    $('.nice-select.subProductTypesID  ul li').click(function () {
        $('#subProductTypesID option').removeAttr('selected').filter('[value=' + $(this).attr('data-value') + ']').attr('selected', true);
    });
});


// detail 

var urlGetSuggestedTopTraders;
function BestSeller(divid) {
    var result = '';
    $.ajax({
        url: urlGetSuggestedProducts,
        data: {},
        error: function (data) {
        },
        success: function (data) {
            $('#' + divid + '').empty().append(data);
        }
        //,
        //beforeSend: function () {
        //    // Show image container
        //    $("#loader2").show();
        //},
        //complete: function (data) {
        //    // Hide image container
        //    $("#loader2").hide();
        //}
    });
}

var urlGetSuggestedProducts;
function F1(type, divid, id, catname, NumberOfProduct) //id= producsid or category or producttype id
{
    var result = '';
    $.ajax({
        url: urlGetSuggestedProducts,
        data: { id: id, suggestedType: type, producttype: id, NumberOfTakeProduct: NumberOfProduct },
        error: function (data) {
        },
        success: function (data) {
            $('#' + divid + '').empty().append(data);
        },
        beforeSend: function () {
            // Show image container
            $("#loader").show();
        },
        complete: function (data) {
            // Hide image container
            $("#loader").hide();
        }
    });
}


// search item

var ProductsFilterModel = {
    "ProductCategoryID": '00000000-0000-0000-0000-000000000000',
    "ProductTypeID": '00000000-0000-0000-0000-000000000000',
    "Pagenumber": 1,
    "Skip": 0,
    "EndPrice": 0,
    "StartPrice": 0,
    "Colors": [],
    "Sizes": [],
    "Units": [],
    "Brands": [],
    "Condition": [],
    "ProductDetailsTypesDetailsList": [],
    "PlaceID": '',
    "dateFrom": '',
    "dateTo": '',
};
var urlShopPartial;
var isLoading = false;
var NotFoundCount = 0;
var text1, text2, errorTickettitle;
function FilteredProducts(type) {
    if (document.querySelector('input[name="ProductTypesID"]:checked') != null) {
        ProductsFilterModel.ProductTypeID = document.querySelector('input[name="ProductTypesID"]:checked').value;
    } else {
        ProductsFilterModel.ProductTypeID = '00000000-0000-0000-0000-000000000000';
    }
    if ($("#Place").val() != "Nothing") { ProductsFilterModel.PlacesID = $("#Place").val(); }
    if ($('#datepickerFrom').val() != "") {
        ProductsFilterModel.StartDate = $('#datepickerFrom').val();
    }
    else {
        ProductsFilterModel.StartDate = null;
    }
    if ($('#datepickerTo').val() != "") {
        ProductsFilterModel.EndDate = $('#datepickerTo').val();
    }
    else {
        ProductsFilterModel.EndDate = null;
    }

    ProductsFilterModel.StartPrice = $('#min-field').val();
    ProductsFilterModel.EndPrice = $('#max-field').val();

    var radios = document.getElementsByClassName("ProductTypesID");
    for (i = 0; i < radios.length; i++) {
        if (radios[i].checked) {
            ProductsFilterModel.ProductTypeID = radios[i].value;
        }
    }
    isLoading = true;
    ProductsFilterModel.ProductTypeID = type;
    var _type = type;
    if (type == undefined) {
        ProductsFilterModel.Pagenumber = 1;
        $('#forfilteredproducts').empty();
    };
    $('#customloader').css('display', 'flex');
    $('[class="categories"]').css('pointer-events', 'none');
    $.ajax({
        type: 'POST',
        url: urlShopPartial,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ 'SelectedFilters': ProductsFilterModel }),
        success: function (data) {
            if (data != "NotFound") {
                $('[class="categories"]').css('pointer-events', '');
                var divContainer = $('#forfilteredproducts');
                divContainer.append(data);
                isLoading = false;
                NotFoundCount = 0;
                $('#total').html($('#resultPartial').val())
            }
            else {
                NotFoundCount = NotFoundCount + 1;
                //console.log(NotFoundCount);
                if (NotFoundCount => 1) {
                    $("#addmore").hide();
                    $('#forfilteredproductserror').append('<br> <div style="margin-left: 15%;margin-top: 3%;margin-right: 15%; ">' +
                        '<div class="">' +
                        '<p>' + text1 + '</p>' +
                        '<h1>' + text2 + '</h1>' +
                        '</div>' +
                        '</div > <br />');

                    if (typeof $('#resultPartial').val() === 'undefined' || $('#resultPartial').val() === null) {
                        $('#total').html('0');
                    } else {
                        $('#total').html(parseInt($('#resultPartial').val()));
                    }
                }
            }
        },
        error: function (xhr, desc, err) {
        },
        beforeSend: function () {
            // Show image container
            $("#loader").show();
        },
        complete: function (data) {
            // Hide image container
            $("#loader").hide();
        }
    });
}

function FilterSubmit() {
    $('#total').val(0);
    ProductsFilterModel.Pagenumber = 1;
    ProductsFilterModel.Brands = [];
    ProductsFilterModel.Sizes = [];
    ProductsFilterModel.Colors = [];
    ProductsFilterModel.Units = [];
    ProductsFilterModel.Condition = [];
    ProductsFilterModel.PlacesID = '';
    if ($("#Place").val() != "Nothing") { ProductsFilterModel.PlacesID = $("#Place").val(); }
    if ($('#datepickerFrom').val() != "") {
        ProductsFilterModel.StartDate = $('#datepickerFrom').val();
    }
    else {
        ProductsFilterModel.StartDate = null;
    }
    if ($('#datepickerTo').val() != "") {
        ProductsFilterModel.EndDate = $('#datepickerTo').val();
    }
    else {
        ProductsFilterModel.EndDate = null;
    }

    ProductsFilterModel.StartPrice = $('#min-field').val();
    ProductsFilterModel.EndPrice = $('#max-field').val();

    var radios = document.getElementsByClassName("ProductTypesID");
    for (i = 0; i < radios.length; i++) {
        if (radios[i].checked) {
            ProductsFilterModel.ProductTypeID = radios[i].value;
        }
    }
    var divContainer = $('#forfilteredproducts');
    $('#forfilteredproductserror').html("");
    divContainer.html(" <br />");
    FilteredProducts(ProductsFilterModel.ProductCategoryID);
}

var isLoading = false;

$(document).ready(function () {
    $('#submitfilter').click(function () {
        $("#addmore").show();
        FilterSubmit();
    });
    $('#addmore').click(function () {
        ProductsFilterModel.Pagenumber += 1;
        FilteredProducts(ProductsFilterModel.ProductCategoryID);
    });
});