
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
 *
 * Creates the background for the schedule grid. Allows the user to interact and create
 * selections. 
 */
class Selection extends PIXI.Graphics {

    constructor(x, y, width, height, interactive) {
        super();
        this.interactive = interactive;
        this.on("pointerdown", draw_select);
        this.make(x, y, width, height, interactive)
    }

    make(x, y, width, height, interactive) {

        this.beginFill(0xCF5474);
        this.drawRect(x, y, width, height);
        this.endFill();
        
    }
}