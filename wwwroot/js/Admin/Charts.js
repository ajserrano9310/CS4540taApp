
var enroll;
var title;
var enddate;
var startdate; 
var seriesDrawn = false;

/**
 * Author:    Alejandro Serrano
 * Partner:   None
 * Date:      12/9/2021
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Alejandro Serrano - This work may not be copied for use in Academic Coursework.
 *
 * I, Alejandro Serrano, certify that I wrote this code from scratch and did
 * not copy it in part or whole from another source.  Any references used
 * in the completion of the assignment are cited in my README file and in
 * the appropriate method header.
 *
 * File Contents
 *
 * Creates a line chart using the Highcharts API. 
 * 
 * User is able to select the enrollment dates from start to finish. 
 */

function drawChart(course, start, end) {

    if (course == 'Course') {
        alert("Please select a course");
        $('#startdates').prop('disabled', false);
        return;
    }

    title = course;
    startdate = parseInt(start);
    enddate = parseInt(end); 

    if (startdate > enddate) {
        alert("Please select a correct range of dates"); 
        $('#startdates').prop('disabled', false);
        return; 
    }

    var params = {
        course: course,
        start: startdate,
        end: enddate
    }

    $.post("/Chart/GetEnrollment", params)
        .done(function (result) {
            enroll = [...result];
            alert(startdate);

            Highcharts.chart('container', {

                title: {
                    text: 'Course Enrollment'
                },

                yAxis: {
                    title: {
                        text: 'Enrollment per day'
                    }
                },

                xAxis: {
                    type: 'datetime',
                    accessibility: {
                        rangeDescription: 'Total Enrollments'
                    }
                },

                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle'
                },

                plotOptions: {
                    series: {
                        label: {
                            connectorAllowed: false
                        },
                        pointStart: Date.UTC(2021, 10, startdate+1),
                        pointInterval: 24 * 3600 * 1000
                    }
                },

                series: [{
                    name: course,
                    data: enroll
                }],

                responsive: {
                    rules: [{
                        condition: {
                            maxWidth: 500
                        },
                        chartOptions: {
                            legend: {
                                layout: 'horizontal',
                                align: 'center',
                                verticalAlign: 'bottom'
                            }
                        }
                    }]
                }
               
            });
            seriesDrawn = true;  
        })

    percentageAreaChart(course, start, end);
}

function addSeries(course, start, end) {

    if (seriesDrawn == false) {
        drawChart(course, start, end);
        return; 
    }

    var params = {
        course: course,
        start: start,
        end: end
    }



    $.post("/Chart/GetEnrollment", params)
        .done(function (result) {
            enroll = result; 
            $("#container").highcharts().addSeries({
                name: course,
                data: enroll

            });
        })

}

function percentageAreaChart(course, start, date) {

    Highcharts.chart('percentage', {
        chart: {
            type: 'area'
        },
        title: {
            text: 'Enrollment Distribution of Core CS classes between Pre and Full Major'
        },
        accessibility: {
            point: {
                valueDescriptionFormat: '{index}. {point.category}, {point.y:,.0f} millions, {point.percentage:.1f}%.'
            }
        },
        xAxis: {
            categories: ['Nov 5', 'Nov 10', 'Nov 13', 'Nov 18', 'Nov 22', 'Nov 25', 'Nov 29'],
            tickmarkPlacement: 'on',
            title: {
                enabled: false
            }
        },
        yAxis: {
            labels: {
                format: '{value}%'
            },
            title: {
                enabled: false
            }
        },
        tooltip: {
            pointFormat: '<span style="color:{series.color}">{series.name}</span>: <b>{point.percentage:.1f}%</b> ({point.y:,.0f} millions)<br/>',
            split: true
        },
        plotOptions: {
            area: {
                stacking: 'percent',
                lineColor: '#ffffff',
                lineWidth: 1,
                marker: {
                    lineWidth: 1,
                    lineColor: '#ffffff'
                }
            }
        },
        series: [{
            name: 'CS 1410',
            data: [3, 141, 189, 213, 222, 231, 235]
        }, {
            name: 'CS 2100',
            data: [4, 51, 108, 128, 132, 143, 147]
        }, {
            name: 'CS 2420',
            data: [5, 166, 233, 258, 268, 276, 284]
        }, {
            name: 'CS 3500',
            data: [0, 10, 25, 40, 41, 45, 46]
        }, {
            name: 'CS 4150',
            data: [0, 83, 122, 127, 140, 144, 146]
            }, {
                name: 'CS 4400',
                data: [3, 95, 121, 131, 132, 136, 140]

            }]
    });

}

