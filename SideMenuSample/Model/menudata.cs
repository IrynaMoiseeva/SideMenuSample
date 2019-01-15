using System;

namespace SideMenuSample.Model
{
    public static class FileJson
    { 

    public const string jsonData1 = @"{     
  'status': 'OK',
  'data': {
    'id': 'MENU_MAIN',
    'accLvl': 0,
    'type': 'MENU_MAIN',
    'dbId': 1,
    'data': [
      {
        'id': '11xx',
        'accLvl': 0,

        'label': 'Settings',
        'children': [
          {
            'id': '22xx',
            'accLvl': 0,

            'label': 'Information',

            'linkType': 'URL',
            'linkOpen': 'EXT',
            'linkValue': 'https://www.spryflash.com/support',
            'dynamic': 'some dynamic not required field'
          },
          {
            'id': '22yy',
            'accLvl': 0,

            'label': 'Email',

            'linkType': 'URL',
            'linkOpen': 'INT',
            'linkValue': 'https://www.spryflash.com/support',
            'dynamic': 'some dynamic not required field'
          },

          {
            'id': '22yy',
            'accLvl': 0,

            'label': 'Feedback',

            'linkType': 'URL',
            'linkOpen': 'INT',
            'linkValue': 'https://www.spryflash.com/support',
            'dynamic': 'some dynamic not required field'
          }
        ]
      },
      {
        'id': '22yy',
        'accLvl': 0,

        'label': 'Logout',

        'linkType': 'SCREEN',

        'linkValue': 'SOME_SCREEN_ID',

        'defSel': 1,

        'dynamic': 'some dynamic not required field'
      }
    ]
  }
}";

    }
}