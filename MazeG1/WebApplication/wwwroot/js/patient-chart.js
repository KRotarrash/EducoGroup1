$(document).ready(function () {
    init();

    function init() {
        var url = '/Hospital/GetChartData?Id=' + modelId;
        $.get(url).done(function (usersData) {
            var ctx = document.getElementById('myChart').getContext('2d');
            var chart = new Chart(ctx, {
                // The type of chart we want to create
                type: 'line',

                // The data for our dataset
                data: {
                    labels: usersData.months,
                    datasets: [{
                        label: 'Count',
                        borderColor: 'rgb(255, 99, 132)',
                        data: usersData.countDetail
                    }]
                },

                // Configuration options go here
                options: {
                    events: ['click']
                }
            });
        });
    }
});