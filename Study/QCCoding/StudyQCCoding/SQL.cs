using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyQCCoding
{
    class SQL
    {

    }



    class DDL
    {
        /*Contains keywords like:
         * 1) CREATE
         * 2) ALTER
         * 3) DROP
         * 4) RENAME
         * 5) TRUNCATE
         * 6) COMMENT
        */
    }


    class DQL
    {
        /*Contains keywords like:
         * 1) SELECT
         * 2) FROM
         * 3) WHERE
        */

        Console.WriteLine("This is a SELECT query: \n SELECT colname1,colname2 +\nFROM tablename(.database)");

        Console.WriteLine("We can have cross joins: \n SELECT colname1,colname2 +\n FROM tablename(.database)+\n CROSS JOIN table.colname AS alias+\n ORDER BY colorders");
        

    }


    class DML
    {
        /*Contains keywords like:
         * 1) INSERT
         * 2) UPDATE
         * 3) DELETE
         * 4) MERGE
         * 5) CALL
         * 6) EXPLAIN PLAN
         * 7) LOCK TABLE
        */
    }


    class DCL
    {
        /*Contains keywords like:
         * 5) GRANT 
         * 6) CONTROL
        */
    }

    class AggregateSQL
    {

    }
}
