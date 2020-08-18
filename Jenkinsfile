pipeline {
  agent {
    node {
      label 'Unity-Windows'
    }
  }
  stages {
    stage('Prepare Environment') {
        steps {
          bat 'mkdir %ARTIFACTS%'
          bat 'mkdir %ARTIFACTS%\\Builds'
        }
      }

      stage('Test: EditMode') {
        environment {
          TEST_PLATFORM = 'EditMode'
        }
        steps {
          bat 'ci/test.bat'
        }
      }
      stage('Test: PlayMode') {
        environment {
          TEST_PLATFORM = 'PlayMode'
        }
        steps {
          bat 'ci/test.bat'
        }
      }
    
    stage('Build: StandaloneWindows64') {
      environment {
        BUILD_TARGET = 'StandaloneWindows64'
      }
      steps {
        bat 'ci/build.bat'
      }
    }

    stage('Build: StandaloneLinux64') {
      environment {
        BUILD_TARGET = 'StandaloneLinux64'
      }
      steps {
        bat 'ci/build.bat'
      }
    }
  }
  environment {
    UNITY_CREDS = credentials('UnityCredentials')
    UNITY_LICENSE_CONTENT = credentials('UnityLicenseFile')
    UNITY_ACTIVATED = 'true'
    UNITY_PATH = 'D:\\Program Files\\Unity Editors\\2020.1.2f1\\Editor\\Unity.exe'
    BUILD_NAME = 'ProjectCoopPuzzleDungeon'
    ARTIFACTS = "${WORKSPACE}\\_artifacts"
    TEST_RESULTS = "${WORKSPACE}\\_testResults"
  }
  post {
    // always {
    //   discordSend(webhookURL: 'https://discordapp.com/api/webhooks/737767932918104244/5Wy_1Jf037_0s4oD90yTeSLKsvchGr0PWBkibVlTOT9003GgWhaREgjt9_D9twvtTGaC', title: JOB_NAME, description: "${currentBuild.currentResult}", link: env.BUILD_URL, result: currentBuild.currentResult)
    //   dir("${TEST_RESULTS}") {
    //     nunit testResultsPattern: '**'
    //   }
    // }
    success {
      dir("${ARTIFACTS}") {
        archiveArtifacts artifacts: '**'
      }
    }
  }
}