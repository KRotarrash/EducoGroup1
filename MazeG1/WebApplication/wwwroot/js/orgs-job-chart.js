$(document).ready(function () {
    init();

    function init() {
        var url = '/Job/GetChartData';
        $.get(url).done(function (usersData) {
            var ctx = document.getElementById('myChart').getContext('2d');
            var chart = new Chart(ctx, {
                // The type of chart we want to create
                type: 'bar',

                // The data for our dataset
                data: {
                    labels: usersData.organizationNames,
                    datasets: [{
                        label: 'Закрытые вакансии',
                        backgroundColor: 'rgb(0, 99, 132)',
                        data: usersData.occupiedJob
                    },
                    {
                        label: 'Свободные вакансии',
                        backgroundColor: 'rgb(255, 99, 132)',
                        data: usersData.freeJob
                    }]
                },

                // Configuration options go here
                options: {
                    scales: {
                        xAxes: [{
                            stacked: true
                        }],
                        yAxes: [{
                            stacked: true
                        }]
                    }
                }
            });
        });
    }
});