/**
 * System configuration for Angular 2 samples
 * Adjust as necessary for your application needs.
 */
(function (global) {
    // map tells the System loader where to look for things
    var map = {
        'app': 'app', // 'dist',

        // angular bundles
        '@angular/core': 'lib/@angular/core/bundles',
        '@angular/common': 'lib/@angular/common/bundles',
        '@angular/compiler': 'lib/@angular/compiler/bundles',
        '@angular/platform-browser': 'lib/@angular/platform-browser/bundles',
        '@angular/platform-browser-dynamic': 'lib/@angular/platform-browser-dynamic/bundles',
        '@angular/http': 'lib/@angular/http/bundles',
        '@angular/router': 'lib/@angular/router/bundles',
        '@angular/forms': 'lib/@angular/forms/bundles',

        // other libraries
        'rxjs': 'lib/rxjs'
    };
    // packages tells the System loader how to load when no filename and/or no extension
    var packages = {
        'app': { main: 'main.js', defaultExtension: 'js' },
        'rxjs': { defaultExtension: 'js' },
    };
    var ngPackageNames = [
      'common',
      'compiler',
      'core',
      'http',
      'platform-browser',
      'platform-browser-dynamic',
      'router',
      'router-deprecated',
      'upgrade',
       'forms'
    ];
    // Individual files (~300 requests):
    function packIndex(pkgName) {
        packages['@angular/' + pkgName] = { main: 'index.js', defaultExtension: 'js' };
    }
    // Bundled (~40 requests):
    function packUmd(pkgName) {
        packages['@angular/' + pkgName] = { main: pkgName + '.umd.js', defaultExtension: 'js' };
    };
    // Most environments should use UMD; some (Karma) need the individual index files
    var setPackageConfig = System.packageWithIndex ? packIndex : packUmd;
    // Add package entries for angular packages
    ngPackageNames.forEach(setPackageConfig);
    var config = {
        map: map,
        packages: packages
    }
    System.config(config);
})(this);
