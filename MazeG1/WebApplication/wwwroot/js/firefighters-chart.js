$(document).ready(function () {
    init();

    function init() {
        FireInspectionChart();
    }

    $('.firefighters-inspection-year').change(function () {
        FireInspectionChart();
    });

    function FireInspectionChart() {
        var fireInspectionYear = $('#FireInspectionBuildingYear').val();
        var url = `/Firefighters/GetChartData?fireInspectionBuildingYear=${fireInspectionYear}`;
        $.get(url).done(function (fireInspectionData) {
            var ctx = document.getElementById('main-inspectionChart').getContext('2d');
            var chart = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul',
                        'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
                    datasets: [{
                        label: 'График осмотра зданий по месяцам',
                        borderColor: 'rgb(255, 99, 132)',
                        data: fireInspectionData.countInspectionsByMonth
                    }]
                },

                options: {

                    scales: {

                        xAxes: [{
                            ticks: {
                                beginAtZero: false,
                                min: 1
                            }
                        }],

                        yAxes: [{
                            ticks: {
                                stepSize: fireInspectionData.countInspectionsStep,
                                suggestedMin: 0,
                                suggestedMax: fireInspectionData.countInspections
                            }
                        }]
                    },

                    events: ['click']
                }
            });
        });
    }

});
