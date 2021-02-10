$(document).ready(function () {
    init();

    function init() {
        var url = '/User/GetChartData';
        $.get(url).done(function (usersData) {
            var ctx = document.getElementById('myChart').getContext('2d');
            var chart = new Chart(ctx, {
                // The type of chart we want to create
                type: 'line',

                // The data for our dataset
                data: {
                    labels: usersData.names,
                    datasets: [{
                        label: 'Height',
                        borderColor: 'rgb(0, 99, 132)',
                        data: usersData.heights
                    },
                    {
                        label: 'Age',
                        borderColor: 'rgb(255, 99, 132)',
                        data: usersData.ages
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