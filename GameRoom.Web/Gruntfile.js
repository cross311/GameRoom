'use strict'
module.exports = function(grunt){
  var config = {};
  config.pkg = require('./package.json');

  config.clean = ['build/']

  config.concat = {
    js: {
      src: [
        'bower_components/angular/angular.js',
        'bower_components/angular-ui-router/release/angular-ui-router.min.js',
        'bower_components/angular-local-storage/dist/angular-local-storage.min.js',
        'src/**/*.js',
        'src/main.js',
        '!src/**/*Spec.js' // include all js files that are not specs
      ],
      dest: 'build/js/main.js',
      options: {
        sourceMap: true,
        sourceMapType: 'inline'
      }
    }
  }

  config.copy = {
    sandman: {
      files: [
        {flatten: true, expand: true, src: 'bower_components/sandman/app/assets/javascripts/*.js', dest: 'build/js', filter: 'isFile'},
        {flatten: true, expand: true, src: 'bower_components/sandman/app/assets/stylesheets/*.css', dest: 'build/css', filter: 'isFile'},
         // fonts and images go in the css folder so we don't have to mess with paths
        {flatten: true, expand: true, src: 'bower_components/sandman/app/assets/fonts/*', dest: 'build/css', filter: 'isFile'},
        {flatten: true, expand: true, src: 'bower_components/sandman/app/assets/images/**', dest: 'build/css', filter: 'isFile'},
      ]
    },
    templates: {
      files: [
        {expand: true, flatten: false, cwd: 'src', src: ['**/*.html', '!index.html'], dest: 'build/templates/'},
      ]
    }
  }

  config.template = {
    prodIndex: {
      files: {
        'build/index.html': ['src/index.html'],  
      },
      options: {
        data: {
          jsFileExt: '.min.js',
          cssFileExt: '.min.css',
          indexExt: '.html',
          config: {
            env: 'production'
          }
        }
      }
    },
    devIndex: {
      files: {
        'build/index.dev.html': ['src/index.html']
      },
      options: {
        data: {
          jsFileExt: '.js',
          cssFileExt: '.css',
          indexExt: '.dev.html',
          config: {
            env: 'development'
          }
        }
      }
    }
  }

  config.connect = {
    dev: {
      options: {
        base: 'build/'  
      }
      
    },
    test: {
      options: {
        base: 'build/',
        port: 8001
      }
    }
  }

  config.cssmin = {
    prod: {
      options: {
        keepSpecialComments: 0
      },
      files: {
        'build/css/main.min.css': ['build/css/main.css']
      }
    }
  }

  config.jasmine = {
    specs: {
      src: ['src/**/*.js', '!src/**/*Spec.js'],
      options: {
        specs: 'src/**/*Spec.js',
        helpers: 'src/**/*Helper.js',
        vendor: [
          'bower_components/angular/angular.js',
          'bower_components/angular-route/angular-route.js',
          'bower_components/angular-mocks/angular-mocks.js',
        ]
      }
    }
  }

  config.sass = {
    main: {
      files: {
        'build/css/main.css': 'src/main.scss'
      },
      options: {
        sourcemap: 'inline',
        bundleExec: true
      }
    }
  }

  config.uglify = {
    prod: {
      options: {
        preserveComments: false
      },
      files: {
        'build/js/main.min.js': ['build/js/main.js']
      }
    }
  }

  config.watch = {
    js: {
      files: ['src/**/*.js', 'src/main.js'],
      tasks: ['eslint', 'concat:js'],
      options: {
        atBegin: true
      }
    },
    css: {
      files: ['src/**/*.scss', 'src/main.scss'],
      tasks: ['scsslint', 'sass'],
      options: {
        atBegin: true
      }
    },
    html: {
      files: ['src/**/*.html'],
      tasks: 'copy:templates',
      options: {
        atBegin: true
      }
    },
    index: {
      files: ['src/index.html'],
      tasks: 'template',
      options: {
        atBegin: true
      }
    },
  }

  config.eslint = {
    options: {
      config: 'config/eslint.json'
    },
    js: ['src/**/*.js']
  }

  config.protractor = {
    options: {
      configFile: "config/e2e.conf.js", 
      keepAlive: true, // If false, the grunt process stops when the test fails.
      noColor: false, 
      args: {}
    },
    e2e: {}
  }

  config.scsslint = {
    allScss: {
      files: {
        src: [
          'src/**/*.scss',
          'src/main.scss'
        ]
      },
      options: {
        bundleExec: true
      }
    }
  }

  grunt.initConfig(config);
  grunt.loadNpmTasks('grunt-aws-s3');
  grunt.loadNpmTasks('grunt-concurrent');
  grunt.loadNpmTasks('grunt-contrib-clean');
  grunt.loadNpmTasks('grunt-contrib-concat');
  grunt.loadNpmTasks('grunt-contrib-connect');
  grunt.loadNpmTasks('grunt-contrib-copy');
  grunt.loadNpmTasks('grunt-contrib-cssmin');
  grunt.loadNpmTasks('grunt-contrib-jasmine');
  grunt.loadNpmTasks('grunt-contrib-sass');
  grunt.loadNpmTasks('grunt-scss-lint');
  grunt.loadNpmTasks('grunt-contrib-uglify');
  grunt.loadNpmTasks('grunt-contrib-watch');
  grunt.loadNpmTasks('grunt-eslint');
  grunt.loadNpmTasks('grunt-protractor-runner');
  grunt.loadNpmTasks('grunt-scss-lint');
  grunt.loadNpmTasks('grunt-template');

  grunt.registerTask('default', ['connect:dev', 'watch']);
  grunt.registerTask('test', ['connect:test',  'eslint', 'scsslint', 'jasmine', 'protractor'])
  grunt.registerTask('build', ['concat', 'copy', 'template', 'sass', 'uglify', 'cssmin', ])
}
