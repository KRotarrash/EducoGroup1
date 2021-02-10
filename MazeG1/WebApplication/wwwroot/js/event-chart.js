$(document).ready(function () {
    init();

    function init() {
        CalendarEventChart();
    }

    $('.calendar-event-year').change(function () {
        CalendarEventChart();
    });

    function CalendarEventChart() {
        var calendarYear = $('#CalendarEventYear').val();
        var url = `/CalendarEvent/GetChartData?calendarEventYear=${calendarYear}`;
        $.get(url).done(function (eventsData) {
            var ctx = document.getElementById('main-eventChart').getContext('2d');
            var chart = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul',
                        'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
                    datasets: [{
                        label: 'События по месяцам',
                        borderColor: 'rgb(255, 99, 132)',
                        data: eventsData.countEventsByMonth
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
                                stepSize: eventsData.countEventsStep,
                                suggestedMin: 0,
                                suggestedMax: eventsData.countEvents
                            }
                        }]
                    },

                    events: ['click']
                }
            });
        });
    }

});
