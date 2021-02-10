$(document).ready(function () {
    init();

    function init() {
        var url = '/Address/GetChartData';
        $.get(url).done(function (addressData){
            var ctx = document.getElementById('addressChart').getContext('2d');
            var chart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: addressData.addressNames,
                    datasets: [{
                        label: 'Количество жильцов',                        
                        borderColor: 'rgb(0, 99, 132)',
                        data: addressData.residents
                    }]
                },
                options: {                    
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true,
                                stepSize: 1
                            }
                        }]
                    }
                }

            });
        });
    }
});
