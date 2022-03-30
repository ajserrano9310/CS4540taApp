/**
 * Author:    Alejandro Serrano
 * Partner:   None
 * Date:      11/21/2021
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Alejandro Serrano - This work may not be copied for use in Academic Coursework.
 *
 * I, Alejandro Serrano, certify that I wrote this code from scratch and did
 * not copy it in part or whole from another source.  Any references used
 * in the completion of the assignment are cited in my README file and in
 * the appropriate method header.
 *
 * File Contents
 * This class creates the required lines for separating between the hours and days. 
 */
class AvailabilityTracker extends PIXI.Graphics
{
    constructor() {
        super();
        this.drawLines();
    }

    drawLines() {
        this.horizontal();
        this.vertical();
    }

    horizontal() {
        var i;
        this.lineStyle(1, 0x888888, 1);
        for (i = 0; i < 14; i++) {
            this.moveTo(100, i * 40);
            this.lineTo(600, i * 40);
        }
    }

    vertical() {
        var j;
        this.lineStyle(1, 0xFCE1DA, 0.5);
        this.moveTo(100, 40);
        this.lineTo(100, 480);
        for (j = 2; j < 7; j++) {
            this.moveTo(100 * j, 40);
            this.lineTo(100 * j, 520);
        }
    }


}