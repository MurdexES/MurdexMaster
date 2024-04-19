import { AudioConfig, AudioInputStream, SpeechTranslationConfig, TranslationRecognizer, SpeechRecognizer, Language } from 'microsoft-cognitiveservices-speech-sdk';
import React, { useState } from 'react';
import { StyleSheet, Text, View, Button } from 'react-native';
import { Picker } from '@react-native-picker/picker';
import * as Speech from 'expo-speech';
import { Audio } from 'expo-av';

export default function App() {
  const [sourceLanguage, setSourceLanguage] = useState('en');
  const [targetLanguage, setTargetLanguage] = useState('en');
  const [translatedText, setTranslatedText] = useState('');
  const [isRecording, setIsRecording] = useState(false);
  const [recognizer, setRecognizer] = useState(null);

  const handleTranslate = async () => {
    
    const speechConfig = SpeechTranslationConfig.fromSubscription("5cadaf5b5c594811868bd46f085f6451", "eastus");
    speechConfig.addTargetLanguage(Language[targetLanguage]);
    speechConfig.speechRecognitionLanguage = Language[sourceLanguage];
    const translator = new TranslationRecognizer(speechConfig);

    translator.recognizing = (s, e) => {
      console.log(`RECOGNIZING: Text=${e.result.text}`);
    };

    translator.recognized = (s, e) => {
      if (e.result.reason === ResultReason.TranslatedSpeech) {
        setTranslatedText(e.result.translations.get(targetLanguage));
      }
    };

    translator.startContinuousRecognitionAsync();
    setRecognizer(translator);
  };

  const handleRecord = async () => {
    setIsRecording(true);
    const { sound } = await Audio.Recording.createAsync(
      Audio.RECORDING_OPTIONS_PRESET_HIGH_QUALITY
    );
    await sound.playAsync();
  };

  const handleStopRecording = async () => {
    setIsRecording(false);
    if (recognizer) {
      await recognizer.stopContinuousRecognitionAsync();
      setRecognizer(null);
    }
  };

  return (
    <View style={styles.container}>
      <Picker
        selectedValue={sourceLanguage}
        onValueChange={(itemValue) => setSourceLanguage(itemValue)}
        style={{ height: 50, width: 150 }}
      >
        <Picker.Item label="English" value="en" />
        <Picker.Item label="Russian" value="ru" />
        <Picker.Item label="Chinese" value="zh-Hans" />
      </Picker>
      <Picker
        selectedValue={targetLanguage}
        onValueChange={(itemValue) => setTargetLanguage(itemValue)}
        style={{ height: 50, width: 150 }}
      >
        <Picker.Item label="English" value="en" />
        <Picker.Item label="Russian" value="ru" />
        <Picker.Item label="Chinese" value="zh-Hans" />
      </Picker>
      <Button style={styles.buttonClass} title="Translate" onPress={handleTranslate} />
      <Text>{translatedText}</Text>
      <Button title="Record" onPress={handleRecord} disabled={isRecording} />
      <Button title="Stop" onPress={handleStopRecording} disabled={!isRecording} />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
  buttonClass: {
    backgroundColor: "#fff"
  }
});
