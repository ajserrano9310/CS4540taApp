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
 * Generates a Pie chart based on the data from the CSV using the Highcharts API. 
 *
 */
function drawPieChart(course, start, end) {

    if (course == null) {
        alert("Please select a course"); 
        return; 
    }


    title = course;

    var params = {
        course: course,
        start: start,
        end: end
    }

    $.post("/Chart/GetEnrollment", params)
        .done(function (result) {
            enroll = result;

            Highcharts.chart('piechart', {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie'
                },
                title: {
                    text: 'November Enrollments'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                    }
                },
                series: [{
                    name: course,
                    colorByPoint: true,
                    data: [{
                        name: 'Nov 1',
                        y: enroll[0],
                        sliced: true,
                        selected: true
                    }, {
                        name: 'Nov 2',
                            y: enroll[1]
                    }, {
                        name: 'Nov 3',
                            y: enroll[2]
                    }, {
                        name: 'Nov 4',
                            y: enroll[3]
                    }, {
                        name: 'Nov 5',
                            y: enroll[4]
                    }, {
                        name: 'Nov 6',
                            y: enroll[5]
                    }, {
                        name: 'Nov 7',
                            y: enroll[6]
                    }, {
                        name: 'Nov 8',
                            y: enroll[7]
                    }, {
                        name: 'Nov 9',
                            y: enroll[8]
                        },
                        {
                            name: 'Nov 10',
                            y: enroll[9]
                        },
                        {
                            name: 'Nov 11',
                            y: enroll[10]
                        },
                        {
                            name: 'Nov 12',
                            y: enroll[11]
                        },
                        {
                            name: 'Nov 13',
                            y: enroll[12]
                        },
                        {
                            name: 'Nov 14',
                            y: enroll[13]
                        },
                        {
                            name: 'Nov 15',
                            y: enroll[14]
                        },
                        {
                            name: 'Nov 16',
                            y: enroll[15]
                        },
                        {
                            name: 'Nov 17',
                            y: enroll[16]
                        },
                        {
                            name: 'Nov 18',
                            y: enroll[17]
                        },
                        {
                            name: 'Nov 19',
                            y: enroll[18]
                        },
                        {
                            name: 'Nov 20',
                            y: enroll[19]
                        },
                        {
                            name: 'Nov 21',
                            y: enroll[20]
                        },
                        {
                            name: 'Nov 22',
                            y: enroll[21]
                        },
                        {
                            name: 'Nov 23',
                            y: enroll[22]
                        },
                        {
                            name: 'Nov 24',
                            y: enroll[23]
                        },
                        {
                            name: 'Nov 25',
                            y: enroll[24]
                        },
                        {
                            name: 'Nov 26',
                            y: enroll[25]
                        },
                        {
                            name: 'Nov 27',
                            y: enroll[26]
                        },
                        {
                            name: 'Nov 28',
                            y: enroll[27]
                        }
                    ]
                }]
            });

        })
}