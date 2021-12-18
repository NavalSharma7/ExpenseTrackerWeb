//const { Alert } = require("bootstrap");
//const { error } = require("jquery");


$(document).ready(function () {

    $.ajax({

        type: "POST",
        url: 'ExpensesReport/ReportCount',
        data: json: JSON,
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: successfunc,
           
    });

    function successfunc(json) {
            var values = json.ReportCount;

            var foodCount = parseInt(values[0]);
            var drinkCount = parseInt(values[1]);
            Highcharts.chart('container', {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie'
                },
                title: {
                    text: 'Your Epense Distribution'
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                accessibility: {
                    point: {
                        valueSuffix: '%'
                    }
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            format: '<b>{point.name}</b>: {point.percentage:.1f} %'
                        }
                    }
                },
                series: [{
                    name: 'Expenses',
                    colorByPoint: true,
                    data: [{
                        name: 'Food',
                        y: foodCount,
                        sliced: true,
                        selected: true
                    }, {
                        name: 'Drinks',
                        y: drinkCount
                    }, {
                        name: 'Firefox',
                        y: 10.85
                    }, {
                        name: 'Edge',
                        y: 4.67
                    }, {
                        name: 'Safari',
                        y: 4.18
                    }, {
                        name: 'Sogou Explorer',
                        y: 1.64
                    }, {
                        name: 'Opera',
                        y: 1.6
                    }, {
                        name: 'QQ',
                        y: 1.2
                    }, {
                        name: 'Other',
                        y: 2.61
                    }]
                }]
            }); 
        }

    function errorfunc() {
        alert(data);
    }

});

