#include <driver/i2s.h>
#include <SPIFFS.h>
#include <Arduino.h>

#define I2S_WS 25
#define I2S_SD 26
#define I2S_SCK 27
#define I2S_PORT I2S_NUM_0
#define I2S_SAMPLE_RATE   (16000)
#define I2S_SAMPLE_BITS   (16)
#define I2S_READ_LEN      (16 * 1024)
#define RECORD_TIME       (10) //Seconds
#define I2S_CHANNEL_NUM   (1)
#define FLASH_RECORD_SIZE (I2S_CHANNEL_NUM * I2S_SAMPLE_RATE * I2S_SAMPLE_BITS / 8 * RECORD_TIME)



class I2S{
    public:
        static void i2s_Init();
        static void i2s_adc_data_scale(uint8_t * d_buff, uint8_t* s_buff, uint32_t len);
        static void example_disp_buf(uint8_t* buf, int length);
        static void wavHeader(byte* header, int wavSize);
        static void listSPIFFS();
        static void SPIFFSInit();
        static void i2s_adc(void *arg);
        static void record();
        static void wavInit();
        static void Init();
        static bool i2s_Busy();
};