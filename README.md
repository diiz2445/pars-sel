# Pars-Sel: Парсер лотов торговой площадки Steam

## Описание проекта
Pars-Sel — это приложение для парсинга лотов с торговой площадки Steam, расчета маржи и отправки уведомлений через Telegram-бота. Проект предназначен для автоматизации мониторинга лотов на рынке Steam, выявления прибыльных торговых возможностей на основе расчета маржи и информирования через Telegram. Проект пишется в первую очередь для собственных нужд.

## Технологический стек
- Язык программирования: C# (.NET Core или .NET Framework, в зависимости от реализации).
- Библиотеки и фреймворки:
  - HttpClient: Для выполнения HTTP-запросов к API или для скрапинга данных.
  - Newtonsoft.Json: Для обработки JSON-ответов от API Steam.
  - Telegram.Bot: Для интеграции с Telegram Bot API для отправки уведомлений.
  - Selenium: Для веб-скрапинга (в случае ограниченного доступа к API).
- База данных:
  - MS SQL для хранения данных о лотах или истории маржи.

   
## Функциональность
- Парсинг лотов: Сбор данных о лотах с торговой площадки Steam (цены, наименования, объемы).
- Расчет маржи: Анализ прибыльности сделок на основе текущих рыночных цен.
- Уведомления: Отправка сообщений в Telegram при обнаружении выгодных лотов.
- Логирование: Запись логов для отслеживания работы приложения и диагностики ошибок.

## Планы по развитию
- Фильтры для лотов: Добавление возможности задавать фильтры (например, по типу предметов, минимальной марже, объему продаж).
- Интеграция с базой данных: Хранение истории лотов и маржи для анализа трендов.
- Расширенные уведомления: Поддержка отправки графиков маржи или статистики в Telegram.
- Многопоточность: Оптимизация парсинга с использованием многопоточных запросов и прокси для повышения производительности.
- Веб-интерфейс: Создание простого desktop-приложения для управления настройками и просмотра результатов.
- Поддержка других платформ: Интеграция с другими торговыми площадками.
- Автоматизация сделок: Возможность автоматического размещения лотов на основе заданных условий.

