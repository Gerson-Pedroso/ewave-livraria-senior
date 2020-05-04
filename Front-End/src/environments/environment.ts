// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  api_endpoint: 'https://localhost:44302',
  firebase: {
      apiKey: "AIzaSyArqzjkqf4edHfvtPofN07aXIOHiN-spDw",
      authDomain: "gbooks-ec349.firebaseapp.com",
      databaseURL: "https://gbooks-ec349.firebaseio.com",
      projectId: "gbooks-ec349",
      storageBucket: "gbooks-ec349.appspot.com",
      messagingSenderId: "443558862728",
      appId: "1:443558862728:web:011da8fd1e9d14aca1643d"
  }
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
