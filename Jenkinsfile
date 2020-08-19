pipeline {
  agent none
  stages {
    stage('Prepare Environment') {
      agent {
        label 'Unity-Windows'
      }
      steps {
        bat 'mkdir %ARTIFACTS%'
        bat 'mkdir %ARTIFACTS%\\Builds'
      }
    }
    stage('Run Tests') {
      agent {
        label 'Unity-Windows'
      }
      stages {
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
      }
    }
    stage('Run Builds') {
      agent {
        label 'Unity-Windows'
      }
      stages {
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
    }
    stage('Stash Files') {
      agent {
        label 'Unity-Windows'
      }
      steps{
        stash name: "artifacts", includes: "${ARTIFACTS}/*"
      }
    }
    stage('Unstash Files') {
      agent {
        label 'master'
      }
      steps{
        dir("${ARTIFACTS}") {
          unstash "artifacts"
        }
      }
    }
    stage('Release') {
      agent {
        label 'master'
      }
      steps{
        sh 'ci/release.sh'
      }
    }
    stage('Archive Artifacts') {
      agent {
        label 'master'
      }
      steps{
        dir("${ARTIFACTS}") {
          archiveArtifacts artifacts: '**'
        }
      }
    }
  }
  environment {
    //UNITY_CREDS = credentials('UnityCredentials')
    //UNITY_LICENSE_CONTENT = credentials('UnityLicenseFile')
    //UNITY_ACTIVATED = 'true'
    UNITY_PATH = 'D:\\Program Files\\Unity Editors\\2020.1.2f1\\Editor\\Unity.exe'
    BUILD_NAME = 'ExtraCreditsGameJam6'

    // GITHUB_RELEASE_PATH = 'D:\\Jenkins\\github-release.exe'
    // RELEASE_REPO = 'ExtraCreditsGameJam6'
    // RELEASE_TAG = 'v0.1'
    // RELEASE_NAME = 'Extra Credits Game Jam 6'
    // RELEASE_DESC = 'Test Release'
    
    GITHUB_TOKEN = credentials('github')
    // GITHUB_API = "https://api.github.com"
    TAG_MAJOR = 0
    TAG_MINOR = 1
    TAG_PATCH = 0
    ARTIFACTS = "${WORKSPACE}\\_artifacts"
    TEST_RESULTS = "${WORKSPACE}\\_testResults"
  }
 //post {
    // always {
    //   discordSend(webhookURL: 'https://discordapp.com/api/webhooks/737767932918104244/5Wy_1Jf037_0s4oD90yTeSLKsvchGr0PWBkibVlTOT9003GgWhaREgjt9_D9twvtTGaC', title: JOB_NAME, description: "${currentBuild.currentResult}", link: env.BUILD_URL, result: currentBuild.currentResult)
    //   dir("${TEST_RESULTS}") {
    //     nunit testResultsPattern: '**'
    //   }
    // }
  //   success {

  //   }
  // }
}