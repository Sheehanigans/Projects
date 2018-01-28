﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;

namespace BattleShip.UI
{
    class StartScreen
    {
        public void Splash()
        {
            Console.WriteLine();
            Console.Write(          
                "   *********************************************************************************************************\n" +
                "   *                                                                                                       *\n" +
                "   *                  *         *  * * *  *       * *     * *      *   *      * * *                        *\n" +
                "   *                   *   *   *   * *    *      *       *   *    *  *  *     * *                          *\n" +
                "   *                     *   *     * * *  * * *   * *     * *    *       *    * * *                        *\n" +
                "   *                                                                                                       *\n" +
                "   *                                        * * *     * *                                                  *\n" +
                "   *                                          *      *   *                                                 *\n" +
                "   *                                          *       * *                                                  *\n" +
                "   *                                                                                                       *\n" +
                "   *      * * *       *   * * * * *  * * * * *  *      * * * *    * * *    *      *   * * * *   * * *      *\n" +
                "   *      *    *     * *      *          *      *      *         *         *      *      *      *    *     *\n" +
                "   *      *  *      * * *     *          *      *      * * *       *       * *  * *      *      *  *       *\n" +
                "   *      *    *   *     *    *          *      *      *             *     *      *      *      *          *\n" +
                "   *      * * *   *       *   *          *      * * *  * * * *   * * *     *      *   * * * *   *          *\n" +
                "   *                                                                                                       *\n" +
                "   *********************************************************************************************************\n");
            Console.WriteLine();
            Console.WriteLine("Press any key to begin");
            Console.ReadLine();
            //Thread.Sleep(5000);
            Console.Clear();
        }
    }
}
